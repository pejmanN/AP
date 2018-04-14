using APT.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APT.Controllers
{
    public class ValuesController : ApiController
    {

        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            using (var context = new MyContext())

            {
                var menus = context.Menus.RecursiveJoin(element => element.Id,
                                                element => element.ParentId,
                                                (Menu element, IEnumerable<MenuDTO> children) => new MenuDTO()
                                                {
                                                    Id = element.Id,
                                                    IsLast = element.IsLast,
                                                    Title = element.Title,
                                                    Children = children.ToList()
                                                }).ToList();
                var p = JsonConvert.SerializeObject(menus);
                List<MenuDTO> leafMenuWithPages = FindTheLeafPages(menus, context);
                var p2 = JsonConvert.SerializeObject(menus);
                return new string[] { "value1", "value2" };
            }
        }

        private List<MenuDTO> FindTheLeafPages(List<MenuDTO> menus, MyContext context)
        {
            List<MenuDTO> leafMenuList = new List<MenuDTO>();
            GetAllLeavesMenu(menus, leafMenuList);
            var allDbPages = context.Pages.ToList();
            FindTheNextPageForEachLeafMenuAndAddedToThem(leafMenuList, allDbPages);
            return leafMenuList;
        }



        private void GetAllLeavesMenu(List<MenuDTO> menus, List<MenuDTO> leaves)
        {
            menus.ForEach(parentMenu =>
            {
                GetRelatedParentLeaves(parentMenu, leaves);
            });

        }

        private void GetRelatedParentLeaves(MenuDTO menu, List<MenuDTO> leaves)
        {
            foreach (MenuDTO child in menu.Children)
            {
                if (child.Children != null)
                    GetRelatedParentLeaves(child, leaves);
                if (child.IsLast)
                    leaves.Add(child);
            }
        }

        private List<MenuDTO> MapToMenuDto(List<Menu> leafMenuList)
        {
            var menuDTOList = new List<MenuDTO>();
            leafMenuList.ForEach(leafMenu =>
            {
                var menuDto = new MenuDTO
                {
                    Id = leafMenu.Id,
                    Title = leafMenu.Title
                };
                menuDTOList.Add(menuDto);
            });
            return menuDTOList;
        }

        private void FindTheNextPageForEachLeafMenuAndAddedToThem(List<MenuDTO> leafMenuList, List<Page> allDbPages)
        {
            foreach (var leafNode in leafMenuList)
            {
                var pageOfLeafMenu = allDbPages
                        .Where(x => x.MenuId == leafNode.Id)
                        .Select(c => new PageDto()
                        {
                            Id = c.Id,
                            Title = c.Title,
                            HasService = c.HasService,
                            NextPage = GetNextPage(allDbPages, c.NextPageId),
                            PageService = GetPageService(allDbPages, c.HasService, c.ServiceId)
                        }).FirstOrDefault();

                if (pageOfLeafMenu != null)
                    //find the line and its button and added to page
                    //FindTheLeafMenuService(page)
                    //pageOfLeafMenu.PageService = GetPageService(pageOfLeafMenu);
                    leafNode.Pages.Add(pageOfLeafMenu);
            }
        }

        private ServiceDto GetPageService(PageDto pageOfLeafMenu)
        {
            throw new NotImplementedException();
        }

        private ServiceDto GetPageService(List<Page> allDbPages, bool? hasService, int? serviceId)
        {
            if (!hasService.Value)
                return null;

            using (var context = new MyContext())
            {
                var pageService = context.Services.FirstOrDefault(x => x.Id == serviceId);
                var serviceSuccessPage = allDbPages.FirstOrDefault(x => x.Id == pageService.SuceessPageId);
                var serviceFailPage = allDbPages.FirstOrDefault(x => x.Id == pageService.FailPageId);

                ServiceDto serviceDto = MapToServiceDto(pageService, serviceSuccessPage, serviceFailPage);
                return serviceDto;
            }
        }

        private ServiceDto MapToServiceDto(Service pageService, Page serviceSuccessPage, Page serviceFailPage)
        {
            var serviceDto = new ServiceDto();
            serviceDto.ServiceTitle = pageService.Title;
            serviceDto.SucessPage = MapPageToPageDto(serviceSuccessPage);
            serviceDto.FailPage = MapPageToPageDto(serviceFailPage);
            return serviceDto;
        }

        private PageDto MapPageToPageDto(Page page)
        {
            var pageDto = new PageDto();
            pageDto.Title = page.Title;
            return pageDto;

        }

        private PageDto GetNextPage(List<Page> allPages, int? nextPageId)
        {
            if (nextPageId == null)
                return null;
            var res = allPages
                   .Where(c => c.Id == nextPageId.Value)
                   .Select(c => new PageDto()
                   {
                       Id = c.Id,
                       Title = c.Title,
                       HasService = c.HasService,
                       NextPage = GetNextPage(allPages, c.NextPageId),
                       PageService = GetPageService(allPages, c.HasService, c.ServiceId)
                   }).FirstOrDefault();

            return res;
        }

        private bool IsLeaf(MenuDTO node)
        {
            if (node.IsLast)
            {
                return true;
            }
            return false;
        }




    }
}
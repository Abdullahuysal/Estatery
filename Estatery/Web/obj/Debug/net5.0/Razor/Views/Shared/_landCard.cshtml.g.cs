#pragma checksum "D:\github\Estatery\Estatery\Web\Views\Shared\_landCard.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ebecad33dc7f63522e51ad98a5aff1357f2dab2d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__landCard), @"mvc.1.0.view", @"/Views/Shared/_landCard.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\github\Estatery\Estatery\Web\Views\_ViewImports.cshtml"
using Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\github\Estatery\Estatery\Web\Views\_ViewImports.cshtml"
using Web.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ebecad33dc7f63522e51ad98a5aff1357f2dab2d", @"/Views/Shared/_landCard.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"74b0619e1a302f0598271da1847e697c39d57b88", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__landCard : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Entities.Concrete.Land>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n<div class=\"card\" style=\"width: 18rem;\">\r\n    <img class=\"card-img-top\"");
            BeginWriteAttribute("src", " src=\"", 106, "\"", 166, 1);
#nullable restore
#line 5 "D:\github\Estatery\Estatery\Web\Views\Shared\_landCard.cshtml"
WriteAttributeValue("", 112, Html.Raw(Model.LandImageUrls.First().Name.ToString()), 112, 54, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" alt=\"Card image cap\">\r\n    <div class=\"card-body\">\r\n        <h5 class=\"card-title\"></h5>\r\n    </div>\r\n    <ul class=\"list-group list-group-flush\">\r\n        <li class=\"list-group-item\">İlan Sahibi: ");
#nullable restore
#line 10 "D:\github\Estatery\Estatery\Web\Views\Shared\_landCard.cshtml"
                                            Write(Model.Advertiser);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n        <li class=\"list-group-item\">Lokasyon ");
#nullable restore
#line 11 "D:\github\Estatery\Estatery\Web\Views\Shared\_landCard.cshtml"
                                        Write(Model.Location.CityName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" / ");
#nullable restore
#line 11 "D:\github\Estatery\Estatery\Web\Views\Shared\_landCard.cshtml"
                                                                   Write(Model.Location.DistrictName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </li>\r\n        <li class=\"list-group-item\">Toplam : ");
#nullable restore
#line 12 "D:\github\Estatery\Estatery\Web\Views\Shared\_landCard.cshtml"
                                        Write(Model.SquareMeter);

#line default
#line hidden
#nullable disable
            WriteLiteral(" m2</li>\r\n        <li class=\"list-group-item\">");
#nullable restore
#line 13 "D:\github\Estatery\Estatery\Web\Views\Shared\_landCard.cshtml"
                               Write(Model.SalesCategory.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </li>\r\n        <li class=\"list-group-item\"></li>\r\n    </ul>\r\n    ");
#nullable restore
#line 16 "D:\github\Estatery\Estatery\Web\Views\Shared\_landCard.cshtml"
Write(Html.ActionLink("Edit", "Update", new { id = Model.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Entities.Concrete.Land> Html { get; private set; }
    }
}
#pragma warning restore 1591
#pragma checksum "C:\Users\Acer\source\repos\ConsultaxMVC\ConsultaxMVC\Views\Pages\IconBox.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a5ec6d09be09575dfc99a76ab77bda406983ccf7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Pages_IconBox), @"mvc.1.0.view", @"/Views/Pages/IconBox.cshtml")]
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
#line 1 "C:\Users\Acer\source\repos\ConsultaxMVC\ConsultaxMVC\Views\_ViewImports.cshtml"
using ConsultaxMVC;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Acer\source\repos\ConsultaxMVC\ConsultaxMVC\Views\_ViewImports.cshtml"
using ConsultaxMVC.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Acer\source\repos\ConsultaxMVC\ConsultaxMVC\Views\_ViewImports.cshtml"
using ConsultaxMVC.ViewModel;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a5ec6d09be09575dfc99a76ab77bda406983ccf7", @"/Views/Pages/IconBox.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"17ad66191f7f90423171610ee92bcec473c185a9", @"/Views/_ViewImports.cshtml")]
    public class Views_Pages_IconBox : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<AllService>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<div class=""page-header"">
    <div class=""container"">
        <div class=""breadc-box no-line"">
            <div class=""row"">
                <div class=""col-md-6"">
                    <h1 class=""page-title"">Icon Boxes</h1>
                </div>
                <div class=""col-md-6 mobile-left text-right"">
                    <ul id=""breadcrumbs"" class=""breadcrumbs none-style"">
                        <li><a href=""index.html"">Home</a></li>
                        <li class=""active"">Icon Boxes</li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
</div>
<section class=""wpb_row row-fluid row-o-equal-height row-flex section-padd"">
    <div class=""container"">
        <div class=""row"">

");
#nullable restore
#line 23 "C:\Users\Acer\source\repos\ConsultaxMVC\ConsultaxMVC\Views\Pages\IconBox.cshtml"
             foreach (var icon in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                <div class=""wpb_column column_container col-sm-6 col-md-4"">
                    <div class=""column-inner"">
                        <div class=""wpb_wrapper"">
                            <div class=""service-box icon-box ionic hover-box"">
                                <i");
            BeginWriteAttribute("class", " class=\"", 1129, "\"", 1147, 1);
#nullable restore
#line 29 "C:\Users\Acer\source\repos\ConsultaxMVC\ConsultaxMVC\Views\Pages\IconBox.cshtml"
WriteAttributeValue("", 1137, icon.Icon, 1137, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("></i>\r\n                                <div class=\"content-box\">\r\n                                    <h4>");
#nullable restore
#line 31 "C:\Users\Acer\source\repos\ConsultaxMVC\ConsultaxMVC\Views\Pages\IconBox.cshtml"
                                   Write(icon.Header);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n                                    <p>");
#nullable restore
#line 32 "C:\Users\Acer\source\repos\ConsultaxMVC\ConsultaxMVC\Views\Pages\IconBox.cshtml"
                                  Write(icon.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
                                    <a class=""link-box pagelink"" href=""service-detail.html"">Read more</a>
                                </div>
                            </div>

                            <div class=""empty_space_30""></div>
                        </div>
                    </div>
                </div>
");
#nullable restore
#line 41 "C:\Users\Acer\source\repos\ConsultaxMVC\ConsultaxMVC\Views\Pages\IconBox.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n    </div>\r\n</section>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<AllService>> Html { get; private set; }
    }
}
#pragma warning restore 1591

#pragma checksum "C:\Users\Acer\source\repos\ConsultaxMVC\ConsultaxMVC\Views\Blog\Detail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d6f41eb9295629343c07824754fecdc39e97740b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Blog_Detail), @"mvc.1.0.view", @"/Views/Blog/Detail.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d6f41eb9295629343c07824754fecdc39e97740b", @"/Views/Blog/Detail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"17ad66191f7f90423171610ee92bcec473c185a9", @"/Views/_ViewImports.cshtml")]
    public class Views_Blog_Detail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\Acer\source\repos\ConsultaxMVC\ConsultaxMVC\Views\Blog\Detail.cshtml"
  
    Blog blog = ViewData["blogDetail"] as Blog;

#line default
#line hidden
#nullable disable
            WriteLiteral("<div style=\"margin:4rem\"  class=\"row\">\r\n    <div  class=\"col-lg-7\">\r\n        <article class=\"post-box post type-post hentry\">\r\n            <div class=\"entry-media\">\r\n                <a href=\"post.html\">\r\n                    <img");
            BeginWriteAttribute("src", " src=\"", 286, "\"", 306, 1);
#nullable restore
#line 10 "C:\Users\Acer\source\repos\ConsultaxMVC\ConsultaxMVC\Views\Blog\Detail.cshtml"
WriteAttributeValue("", 292, blog.PhotoUrl, 292, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 307, "\"", 313, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                </a>
            </div>
            <div class=""inner-post"">
                <header class=""entry-header"">

                    <div class=""entry-meta"">
                        <span class=""posted-on"">
                            <time class=""entry-date published"">August 14, 2018</time>
                        </span>
                        <span class=""posted-in"">
                            <a href=""#"" rel=""category tag"">");
#nullable restore
#line 21 "C:\Users\Acer\source\repos\ConsultaxMVC\ConsultaxMVC\Views\Blog\Detail.cshtml"
                                                      Write(blog.Category);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                        </span>\r\n                    </div>\r\n                    <!-- .entry-meta -->\r\n                    <h4 class=\"entry-title\"><a href=\"post.html\" rel=\"bookmark\">");
#nullable restore
#line 25 "C:\Users\Acer\source\repos\ConsultaxMVC\ConsultaxMVC\Views\Blog\Detail.cshtml"
                                                                          Write(blog.Header);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></h4>\r\n                </header>\r\n                <!-- .entry-header -->\r\n\r\n                <div class=\"entry-summary\">\r\n                    <p>");
#nullable restore
#line 30 "C:\Users\Acer\source\repos\ConsultaxMVC\ConsultaxMVC\Views\Blog\Detail.cshtml"
                  Write(blog.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
                </div>
                <!-- .entry-content -->

                <footer class=""entry-footer"">
                    <a class=""post-link"" href=""post.html"">Read more</a>
                </footer>
                <!-- .entry-footer -->
            </div>
        </article>
    </div>
    <div class=""col-lg-4"">
");
#nullable restore
#line 42 "C:\Users\Acer\source\repos\ConsultaxMVC\ConsultaxMVC\Views\Blog\Detail.cshtml"
         foreach (var blogDetail in ViewData["blogs"] as List<Blog>)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <a");
            BeginWriteAttribute("href", " href=\"", 1579, "\"", 1613, 2);
            WriteAttributeValue("", 1586, "/Blog/Detail/", 1586, 13, true);
#nullable restore
#line 44 "C:\Users\Acer\source\repos\ConsultaxMVC\ConsultaxMVC\Views\Blog\Detail.cshtml"
WriteAttributeValue("", 1599, blogDetail.ID, 1599, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                <div class=\"row align-items-center\">\r\n                    <div class=\"col-lg-4\">\r\n                        <img class=\"img-fluid\"");
            BeginWriteAttribute("src", " src=\"", 1761, "\"", 1787, 1);
#nullable restore
#line 47 "C:\Users\Acer\source\repos\ConsultaxMVC\ConsultaxMVC\Views\Blog\Detail.cshtml"
WriteAttributeValue("", 1767, blogDetail.PhotoUrl, 1767, 20, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                    </div>\r\n                    <div style=\"margin-bottom:20px\" class=\"col-lg-6\">\r\n                        <h6 style=\"margin:0px\">");
#nullable restore
#line 50 "C:\Users\Acer\source\repos\ConsultaxMVC\ConsultaxMVC\Views\Blog\Detail.cshtml"
                                          Write(blogDetail.Header);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\r\n                        <span>");
#nullable restore
#line 51 "C:\Users\Acer\source\repos\ConsultaxMVC\ConsultaxMVC\Views\Blog\Detail.cshtml"
                         Write(blogDetail.PublishDate.ToString("dd MMM yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                    </div>\r\n                </div>\r\n            </a>\r\n");
#nullable restore
#line 55 "C:\Users\Acer\source\repos\ConsultaxMVC\ConsultaxMVC\Views\Blog\Detail.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591

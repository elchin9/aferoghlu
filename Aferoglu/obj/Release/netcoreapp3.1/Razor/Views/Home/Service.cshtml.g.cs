#pragma checksum "C:\Users\User\source\repos\Aferoglu\Aferoglu\Views\Home\Service.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "100ac8db03c488784cea245eb1d5f73b3ad74f4c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Service), @"mvc.1.0.view", @"/Views/Home/Service.cshtml")]
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
#line 1 "C:\Users\User\source\repos\Aferoglu\Aferoglu\Views\_ViewImports.cshtml"
using Aferoglu;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\User\source\repos\Aferoglu\Aferoglu\Views\_ViewImports.cshtml"
using Aferoglu.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\User\source\repos\Aferoglu\Aferoglu\Views\_ViewImports.cshtml"
using Microsoft.Extensions.Configuration;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"100ac8db03c488784cea245eb1d5f73b3ad74f4c", @"/Views/Home/Service.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4e333f3888b72fa84fd220bec584a0f4f88cecd4", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Service : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<OurTeamLang>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "C:\Users\User\source\repos\Aferoglu\Aferoglu\Views\Home\Service.cshtml"
    ViewData["Title"] = "Service";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<!-- ======================== Main header ======================== -->\r\n\r\n<section class=\"main-header\" style=\"background-image:url(../../assets/images/gallery-3.jpg)\">\r\n    <header>\r\n        <div class=\"container\">\r\n            <h1 class=\"h2 title\">");
#nullable restore
#line 12 "C:\Users\User\source\repos\Aferoglu\Aferoglu\Views\Home\Service.cshtml"
                            Write(Model.FullName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n        </div>\r\n    </header>\r\n</section>\r\n\r\n\r\n<section");
            BeginWriteAttribute("class", " class=\"", 398, "\"", 406, 0);
            EndWriteAttribute();
            WriteLiteral(" >\r\n    <header>\r\n        <div class=\"container\">\r\n            <div class=\"row\">\r\n                <div class=\"col-12\">\r\n                    <p>");
#nullable restore
#line 23 "C:\Users\User\source\repos\Aferoglu\Aferoglu\Views\Home\Service.cshtml"
                  Write(Model.Profession);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </header>\r\n</section>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<OurTeamLang> Html { get; private set; }
    }
}
#pragma warning restore 1591

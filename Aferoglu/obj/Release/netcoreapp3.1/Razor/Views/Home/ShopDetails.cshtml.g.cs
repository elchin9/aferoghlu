#pragma checksum "C:\Users\User\source\repos\Aferoglu\Aferoglu\Views\Home\ShopDetails.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "649c6d345432a8173416827b8ef534ea326ed901"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_ShopDetails), @"mvc.1.0.view", @"/Views/Home/ShopDetails.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"649c6d345432a8173416827b8ef534ea326ed901", @"/Views/Home/ShopDetails.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4e333f3888b72fa84fd220bec584a0f4f88cecd4", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_ShopDetails : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ProductLang>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("height", new global::Microsoft.AspNetCore.Html.HtmlString("500"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "C:\Users\User\source\repos\Aferoglu\Aferoglu\Views\Home\ShopDetails.cshtml"
    string _lang = ViewBag.Lang ?? "az";
    var controller = ViewContext.RouteData.Values["Controller"].ToString().ToLower();
    var action = ViewContext.RouteData.Values["Action"].ToString().ToLower();
    

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<!-- ========================  Main header ======================== -->\r\n\r\n<section class=\"main-header\" style=\"background-image:url(../../assets/images/gallery-2.jpg)\">\r\n    <header>\r\n        <div class=\"container\">\r\n            <h1 class=\"h2 title\">");
#nullable restore
#line 15 "C:\Users\User\source\repos\Aferoglu\Aferoglu\Views\Home\ShopDetails.cshtml"
                            Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h1>
        </div>
    </header>
</section>

<!-- ========================  Product ======================== -->

<section class=""product"">
    <div class=""main"">
        <div class=""container"">
            <div class=""row product-flex"">

                <!-- product flex is used only for mobile order -->
                <!-- on mobile 'product-flex-info' goes bellow gallery 'product-flex-gallery' -->

                <div class=""col-md-4 col-sm-12 product-flex-info"">
                    <div class=""clearfix"">

                        <!-- === product-title === -->

                        <h1 class=""title"" data-title=""");
#nullable restore
#line 35 "C:\Users\User\source\repos\Aferoglu\Aferoglu\Views\Home\ShopDetails.cshtml"
                                                 Write(Model.Product.Category.CategoryLangs.FirstOrDefault().Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">");
#nullable restore
#line 35 "C:\Users\User\source\repos\Aferoglu\Aferoglu\Views\Home\ShopDetails.cshtml"
                                                                                                              Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h1>

                        <div class=""clearfix"">

                            <!-- === price wrapper === -->

                            <div class=""price"">
                                <span class=""h3"">
                                    ");
#nullable restore
#line 43 "C:\Users\User\source\repos\Aferoglu\Aferoglu\Views\Home\ShopDetails.cshtml"
                               Write(Model.Product.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                </span>
                            </div>
                            <hr />

                            <!-- === info-box === -->

                            <div class=""info-box"">
                                <span><strong>");
#nullable restore
#line 51 "C:\Users\User\source\repos\Aferoglu\Aferoglu\Views\Home\ShopDetails.cshtml"
                                         Write(_configuration[$"Producer:{_lang}"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong></span>\r\n                                <span>");
#nullable restore
#line 52 "C:\Users\User\source\repos\Aferoglu\Aferoglu\Views\Home\ShopDetails.cshtml"
                                 Write(Model.Maifacturer);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                            </div>\r\n\r\n                            <!-- === info-box === -->\r\n\r\n                            <div class=\"info-box\">\r\n                                <span><strong>");
#nullable restore
#line 58 "C:\Users\User\source\repos\Aferoglu\Aferoglu\Views\Home\ShopDetails.cshtml"
                                         Write(_configuration[$"Info:{_lang}"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong></span>\r\n                                <span>");
#nullable restore
#line 59 "C:\Users\User\source\repos\Aferoglu\Aferoglu\Views\Home\ShopDetails.cshtml"
                                 Write(Model.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                            </div>\r\n\r\n                            <!-- === info-box === -->\r\n\r\n                            <div class=\"info-box\">\r\n                                <span><strong>");
#nullable restore
#line 65 "C:\Users\User\source\repos\Aferoglu\Aferoglu\Views\Home\ShopDetails.cshtml"
                                         Write(_configuration[$"InStock:{_lang}"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong></span>\r\n");
#nullable restore
#line 66 "C:\Users\User\source\repos\Aferoglu\Aferoglu\Views\Home\ShopDetails.cshtml"
                                 if (Model.Product.IsStock)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <span><i class=\"fa fa-check-square-o\"></i> In stock</span>\r\n");
#nullable restore
#line 69 "C:\Users\User\source\repos\Aferoglu\Aferoglu\Views\Home\ShopDetails.cshtml"
                                }
                                else
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <span><i class=\"fa fa-truck\"></i> Out of stock</span>\r\n");
#nullable restore
#line 73 "C:\Users\User\source\repos\Aferoglu\Aferoglu\Views\Home\ShopDetails.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </div>\r\n\r\n                            <hr />\r\n\r\n                            <!-- === info-box === -->\r\n\r\n                            <div class=\"info-box\">\r\n                                <span>");
#nullable restore
#line 82 "C:\Users\User\source\repos\Aferoglu\Aferoglu\Views\Home\ShopDetails.cshtml"
                                 Write(_configuration[$"Price:{_lang}"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
                            </div>




                        </div> <!--/clearfix-->
                    </div> <!--/product-info-wrapper-->
                </div> <!--/col-md-4-->
                <!-- === product item gallery === -->

                <div class=""col-md-8 col-sm-12 product-flex-gallery"">

                    <!-- === add to cart === -->

                    <a href=""https://api.whatsapp.com/send?phone=994509902090"" target=""_blank"" class=""btn btn-buy"" data-text=""");
#nullable restore
#line 97 "C:\Users\User\source\repos\Aferoglu\Aferoglu\Views\Home\ShopDetails.cshtml"
                                                                                                                         Write(_configuration[$"Buy:{_lang}"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\"></a>\r\n\r\n\r\n                    <!-- === product gallery === -->\r\n\r\n                    <div class=\"owl-product-gallery\">\r\n");
#nullable restore
#line 103 "C:\Users\User\source\repos\Aferoglu\Aferoglu\Views\Home\ShopDetails.cshtml"
                         foreach (var p in Model.Product.Photos)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "649c6d345432a8173416827b8ef534ea326ed90111637", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 3967, "~/images/", 3967, 9, true);
#nullable restore
#line 105 "C:\Users\User\source\repos\Aferoglu\Aferoglu\Views\Home\ShopDetails.cshtml"
AddHtmlAttributeValue("", 3976, p.PhotoURL, 3976, 11, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 106 "C:\Users\User\source\repos\Aferoglu\Aferoglu\Views\Home\ShopDetails.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n                </div>\r\n\r\n            </div>\r\n        </div>\r\n    </div>\r\n\r\n</section>\r\n\r\n<!-- ========================  Product info popup - quick view ======================== -->\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IConfiguration _configuration { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ProductLang> Html { get; private set; }
    }
}
#pragma warning restore 1591

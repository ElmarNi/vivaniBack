#pragma checksum "C:\Users\User\Desktop\Vivani Back\Vivani Back\Areas\admin\Views\WhyUs\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ba6daef105c6c15991acbe7ab921f77949660d45"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_admin_Views_WhyUs_Index), @"mvc.1.0.view", @"/Areas/admin/Views/WhyUs/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/admin/Views/WhyUs/Index.cshtml", typeof(AspNetCore.Areas_admin_Views_WhyUs_Index))]
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
#line 1 "C:\Users\User\Desktop\Vivani Back\Vivani Back\Areas\admin\Views\_ViewImports.cshtml"
using VivaniBack;

#line default
#line hidden
#line 2 "C:\Users\User\Desktop\Vivani Back\Vivani Back\Areas\admin\Views\_ViewImports.cshtml"
using VivaniBack.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ba6daef105c6c15991acbe7ab921f77949660d45", @"/Areas/admin/Views/WhyUs/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"359db6935a9e4d663ddeea509311af997d31f77a", @"/Areas/admin/Views/_ViewImports.cshtml")]
    public class Areas_admin_Views_WhyUs_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WhyChooseUsAdminVm>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-warning"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "update", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(27, 759, true);
            WriteLiteral(@"<section>
    <div class=""container"">
        <div class=""row"">
            <div class=""col-12"">
                <h1 class=""text-center mb-5"">Niyə bizi seçməlisiniz?</h1>
                <div class=""table-responsive"">
                    <table class=""table table-hover"">
                        <thead class=""thead-dark"">
                            <tr>
                                <th scope=""col"">#</th>
                                <th scope=""col"">Başlıq</th>
                                <th scope=""col"">Məzmun</th>
                                <th scope=""col"">İkon</th>
                                <th scope=""col""></th>
                            </tr>
                        </thead>
                        <tbody>
");
            EndContext();
#line 19 "C:\Users\User\Desktop\Vivani Back\Vivani Back\Areas\admin\Views\WhyUs\Index.cshtml"
                             foreach (var item in Model.WhyChooseUs)
                            {

#line default
#line hidden
            BeginContext(887, 90, true);
            WriteLiteral("                                <tr>\r\n                                    <th scope=\"row\">");
            EndContext();
            BeginContext(978, 7, false);
#line 22 "C:\Users\User\Desktop\Vivani Back\Vivani Back\Areas\admin\Views\WhyUs\Index.cshtml"
                                               Write(item.Id);

#line default
#line hidden
            EndContext();
            BeginContext(985, 47, true);
            WriteLiteral("</th>\r\n                                    <td>");
            EndContext();
            BeginContext(1033, 12, false);
#line 23 "C:\Users\User\Desktop\Vivani Back\Vivani Back\Areas\admin\Views\WhyUs\Index.cshtml"
                                   Write(item.Heading);

#line default
#line hidden
            EndContext();
            BeginContext(1045, 47, true);
            WriteLiteral("</td>\r\n                                    <td>");
            EndContext();
            BeginContext(1093, 12, false);
#line 24 "C:\Users\User\Desktop\Vivani Back\Vivani Back\Areas\admin\Views\WhyUs\Index.cshtml"
                                   Write(item.Content);

#line default
#line hidden
            EndContext();
            BeginContext(1105, 49, true);
            WriteLiteral("</td>\r\n                                    <td><i");
            EndContext();
            BeginWriteAttribute("class", " class=\"", 1154, "\"", 1172, 1);
#line 25 "C:\Users\User\Desktop\Vivani Back\Vivani Back\Areas\admin\Views\WhyUs\Index.cshtml"
WriteAttributeValue("", 1162, item.Icon, 1162, 10, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1173, 94, true);
            WriteLiteral("></i></td>\r\n                                    <td>\r\n                                        ");
            EndContext();
            BeginContext(1267, 81, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "46ba017332224b8383515e961fddb705", async() => {
                BeginContext(1338, 6, true);
                WriteLiteral("Yenilə");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 27 "C:\Users\User\Desktop\Vivani Back\Vivani Back\Areas\admin\Views\WhyUs\Index.cshtml"
                                                                                         WriteLiteral(item.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1348, 84, true);
            WriteLiteral("\r\n                                    </td>\r\n                                </tr>\r\n");
            EndContext();
#line 30 "C:\Users\User\Desktop\Vivani Back\Vivani Back\Areas\admin\Views\WhyUs\Index.cshtml"
                            }

#line default
#line hidden
            BeginContext(1463, 146, true);
            WriteLiteral("                        </tbody>\r\n                    </table>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</section>");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WhyChooseUsAdminVm> Html { get; private set; }
    }
}
#pragma warning restore 1591

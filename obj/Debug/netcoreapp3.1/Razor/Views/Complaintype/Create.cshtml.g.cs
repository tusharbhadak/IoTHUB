#pragma checksum "C:\Users\Tushar\source\repos\IoTHUB v1.0\Views\Complaintype\Create.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b07d9daf3e95d51c7ec26caee954eb599f9b620b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Complaintype_Create), @"mvc.1.0.view", @"/Views/Complaintype/Create.cshtml")]
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
#line 1 "C:\Users\Tushar\source\repos\IoTHUB v1.0\Views\_ViewImports.cshtml"
using IoTHUB_v1._0;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Tushar\source\repos\IoTHUB v1.0\Views\_ViewImports.cshtml"
using IoTHUB_v1._0.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b07d9daf3e95d51c7ec26caee954eb599f9b620b", @"/Views/Complaintype/Create.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6f550c6c2df213f796a776decb67f955a1ea1e59", @"/Views/_ViewImports.cshtml")]
    public class Views_Complaintype_Create : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IoTHUB_v1._0.Models.ComplaintypeTbl>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Tushar\source\repos\IoTHUB v1.0\Views\Complaintype\Create.cshtml"
  
    ViewData["Title"] = "Create";
    Layout = "~/Views/Shared/Masteradmin.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<link rel=""stylesheet"" href=""//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css"">
<link rel=""stylesheet"" href=""/resources/demos/style.css"">
<script src=""https://code.jquery.com/jquery-1.12.4.js""></script>
<script src=""https://code.jquery.com/ui/1.12.1/jquery-ui.js""></script>


<div class=""card card-body breadcrumbs"">
    <div class=""breadcrumbs-inner"">
        <div class=""row m-0"">
            <div class=""col-sm-4"">
                <div class=""page-header float-left"">
                    <div class=""page-title"">
                        <h1>Complain Type</h1>
                    </div>
                </div>
            </div>
            <div class=""col-sm-8"">
                <div class=""page-header float-right"">
                    <div class=""page-title"">
                        <ol class=""breadcrumb text-right"">
                            <li>
                                <a");
            BeginWriteAttribute("href", " href=\"", 1057, "\"", 1084, 1);
#nullable restore
#line 28 "C:\Users\Tushar\source\repos\IoTHUB v1.0\Views\Complaintype\Create.cshtml"
WriteAttributeValue("", 1064, Url.Action("Index"), 1064, 20, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" class=""btn btn-sm btn-info right"">
                                    <i class=""fa fa-arrow-left""></i> Back
                                </a>
                            </li>

                        </ol>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>

");
#nullable restore
#line 41 "C:\Users\Tushar\source\repos\IoTHUB v1.0\Views\Complaintype\Create.cshtml"
 using (Html.BeginForm())
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 43 "C:\Users\Tushar\source\repos\IoTHUB v1.0\Views\Complaintype\Create.cshtml"
Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"container\">\r\n        <div class=\"row\">\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b07d9daf3e95d51c7ec26caee954eb599f9b620b5960", async() => {
                WriteLiteral(@"
                <div class=""col-xs-12 col-lg-12 col-md-12 col-sm-12"">
                    <div class=""card"">
                        <div class=""card-header"">

                        </div>


                        <div class=""form-group"">
                            <label class=""control-label col-md-2"" for=""quantity"">Complain Type</label>
                            <div class=""col-md-7"">
                                ");
#nullable restore
#line 58 "C:\Users\Tushar\source\repos\IoTHUB v1.0\Views\Complaintype\Create.cshtml"
                           Write(Html.EditorFor(model => model.CompType, new { htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                ");
#nullable restore
#line 59 "C:\Users\Tushar\source\repos\IoTHUB v1.0\Views\Complaintype\Create.cshtml"
                           Write(Html.ValidationMessageFor(model => model.CompType, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                            </div>
                        </div>
                        <div class=""form-group"">
                            <label class=""control-label col-md-2"" for=""quantity"">Created Date</label>
                            <div class=""col-md-7"">
                                ");
#nullable restore
#line 65 "C:\Users\Tushar\source\repos\IoTHUB v1.0\Views\Complaintype\Create.cshtml"
                           Write(Html.EditorFor(model => model.Createddate, new { htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                ");
#nullable restore
#line 66 "C:\Users\Tushar\source\repos\IoTHUB v1.0\Views\Complaintype\Create.cshtml"
                           Write(Html.ValidationMessageFor(model => model.Createddate, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                            </div>
                        </div>
                        <div class=""form-group"">
                            <div class=""col-md-offset-2 col-md-10"">
                                <input type=""submit"" value=""Create"" class=""btn btn-success"" />

                            </div>
                        </div>
                    </div>
                </div>
            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n");
#nullable restore
#line 80 "C:\Users\Tushar\source\repos\IoTHUB v1.0\Views\Complaintype\Create.cshtml"

}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IoTHUB_v1._0.Models.ComplaintypeTbl> Html { get; private set; }
    }
}
#pragma warning restore 1591

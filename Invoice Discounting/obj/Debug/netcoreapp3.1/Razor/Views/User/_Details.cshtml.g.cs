#pragma checksum "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\User\_Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "26305ca92a9cb4249c2e72bb45f6619a745ce8e5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_User__Details), @"mvc.1.0.view", @"/Views/User/_Details.cshtml")]
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
#line 1 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\_ViewImports.cshtml"
using Invoice_Discounting;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\_ViewImports.cshtml"
using Invoice_Discounting.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\_ViewImports.cshtml"
using Invoice_Discounting.ViewModel;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"26305ca92a9cb4249c2e72bb45f6619a745ce8e5", @"/Views/User/_Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5e7e6c2b2e2093347ee78387d906f49a77b633a7", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_User__Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Users>
    #nullable disable
    {
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
            WriteLiteral(@"

<div class=""modal fade"" tabindex=""-1"" role=""dialog"" aria-labelledby=""myLargeModalLabel"" aria-hidden=""true"">
	<div class=""modal-dialog modal-dialog-scrollable modal-dialog-centered modal-lg"">
		<div class=""modal-content"">
			<div class=""modal-header"">
				<h4 class=""modal-title"" id=""myLargeModalLabel"">View User Details</h4>
				<button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
					<span aria-hidden=""true"">×</span>
				</button>
			</div>
			<div class=""modal-body"">
				<div class=""tb-card-body"">
					<div class=""tb-padd-lr-30 tb-alert-wrap"">
						<div class=""tb-height-b25 tb-height-lg-b25""></div>
                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "26305ca92a9cb4249c2e72bb45f6619a745ce8e54358", async() => {
                WriteLiteral("\r\n                            <div class=\"form-row\">\r\n                                <div class=\"form-group col-md-6\">\r\n                                    <label for=\"inputEmail4\">UserName</label>\r\n                                    ");
#nullable restore
#line 21 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\User\_Details.cshtml"
                               Write(Html.EditorFor(model => model.USERNAME, new { htmlAttributes = new { @class = "form-control", @readonly = "readonly" } }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                </div>\r\n                                <div class=\"form-group col-md-6\">\r\n                                    <label for=\"inputEmail4\">Email</label>\r\n                                    ");
#nullable restore
#line 25 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\User\_Details.cshtml"
                               Write(Html.EditorFor(model => model.EMAIL, new { htmlAttributes = new { @class = "form-control", @readonly = "readonly" } }));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                                </div>

                            </div>
                            <div class=""form-row"">
                                <div class=""form-group col-md-6"">
                                    <label for=""inputEmail4"">First Name</label>
                                    ");
#nullable restore
#line 32 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\User\_Details.cshtml"
                               Write(Html.EditorFor(model => model.FIRSTNAME, new { htmlAttributes = new { @class = "form-control", @readonly = "readonly" } }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                </div>\r\n                                <div class=\"form-group col-md-6\">\r\n                                    <label for=\"inputEmail4\">Last Name</label>\r\n                                    ");
#nullable restore
#line 36 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\User\_Details.cshtml"
                               Write(Html.EditorFor(model => model.LASTNAME, new { htmlAttributes = new { @class = "form-control", @readonly = "readonly" } }));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"

                                </div>
                            </div>
                            <div class=""form-row"">
                                <div class=""form-group col-md-6"">
                                    <label for=""inputEmail4"">User Class</label>
                                    ");
#nullable restore
#line 43 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\User\_Details.cshtml"
                               Write(Html.EditorFor(model => model.USERCLASS, new { htmlAttributes = new { @class = "form-control", @readonly = "readonly" } }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                </div>\r\n                                <div class=\"form-group col-md-6\">\r\n                                    <label for=\"inputEmail4\">User Type</label>\r\n                                    ");
#nullable restore
#line 47 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\User\_Details.cshtml"
                               Write(Html.EditorFor(model => model.USERTYPE, new { htmlAttributes = new { @class = "form-control", @readonly = "readonly" } }));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"

                                </div>
                            </div>
                            <div class=""form-row"">
                                <div class=""form-group col-md-6"">
                                    <label for=""inputEmail4"">Role</label>
                                    ");
#nullable restore
#line 54 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\User\_Details.cshtml"
                               Write(Html.EditorFor(model => model.ROLENAME, new { htmlAttributes = new { @class = "form-control", @readonly = "readonly" } }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                </div>\r\n                                <div class=\"form-group col-md-6\">\r\n                                    <label for=\"inputEmail4\">Status</label>\r\n");
#nullable restore
#line 58 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\User\_Details.cshtml"
                                     if (Model.STATUS == 1)
                                    {
                                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 60 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\User\_Details.cshtml"
                                   Write(Html.Editor("ACTIVE", new { htmlAttributes = new { @class = "form-control", @readonly = "readonly" } }));

#line default
#line hidden
#nullable disable
#nullable restore
#line 60 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\User\_Details.cshtml"
                                                                                                                                                ;
                                    }
                                    else
                                    {
                                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 64 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\User\_Details.cshtml"
                                   Write(Html.Editor("DISABLED", new { htmlAttributes = new { @class = "form-control", @readonly = "readonly" } }));

#line default
#line hidden
#nullable disable
#nullable restore
#line 64 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\User\_Details.cshtml"
                                                                                                                                                  ;
                                    }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                                </div>
                            </div>

                            <div class=""form-row"">
                                <div class=""form-group col-md-6 "">
                                    <label for=""inputEmail4"">Initiator</label>
                                    ");
#nullable restore
#line 72 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\User\_Details.cshtml"
                               Write(Html.EditorFor(model => model.INPUTTERNAME, new { htmlAttributes = new { @class = "form-control", @readonly = "readonly" } }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n\r\n                                </div>\r\n                                <div class=\"form-group col-md-6\">\r\n                                    <label for=\"inputEmail4\">Date Initiated</label>\r\n                                    ");
#nullable restore
#line 77 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\User\_Details.cshtml"
                               Write(Html.EditorFor(model => model.CREATEDDATE, new { htmlAttributes = new { @class = "form-control", @readonly = "readonly" } }));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"

                                </div>

                            </div>
                            <div class=""form-row"">
                                <div class=""form-group col-md-6 "">
                                    <label for=""inputEmail4"">Authorizer</label>
                                    ");
#nullable restore
#line 85 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\User\_Details.cshtml"
                               Write(Html.EditorFor(model => model.AUTHORIZERNAME, new { htmlAttributes = new { @class = "form-control", @readonly = "readonly" } }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n\r\n                                </div>\r\n                                <div class=\"form-group col-md-6\">\r\n                                    <label for=\"inputEmail4\">Date Authorized</label>\r\n                                    ");
#nullable restore
#line 90 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\User\_Details.cshtml"
                               Write(Html.EditorFor(model => model.DATEAUTHORIZED, new { htmlAttributes = new { @class = "form-control", @readonly = "readonly" } }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n\r\n                                </div>\r\n\r\n                            </div>\r\n                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
						<div class=""tb-height-b15 tb-height-lg-b15""></div>
					</div>
				</div>
			</div>

			<div class=""modal-footer"">
				<button type=""button"" class=""btn btn-secondary"" data-dismiss=""modal"">Close</button>
			</div>
		</div>
	</div>
</div>

");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Users> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591

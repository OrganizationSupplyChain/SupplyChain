#pragma checksum "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Corporate\_Create.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d1c3054bfe2ff6d42d5f22c86f09f2eecfefa3b3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Corporate__Create), @"mvc.1.0.view", @"/Views/Corporate/_Create.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d1c3054bfe2ff6d42d5f22c86f09f2eecfefa3b3", @"/Views/Corporate/_Create.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5e7e6c2b2e2093347ee78387d906f49a77b633a7", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Corporate__Create : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CorporateViewModel>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Corporate", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "_Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("autocomplete", new global::Microsoft.AspNetCore.Html.HtmlString("off"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n\t");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d1c3054bfe2ff6d42d5f22c86f09f2eecfefa3b34940", async() => {
                WriteLiteral("\r\n\r\n");
                WriteLiteral(@" <div class=""modal fade"" tabindex=""-1"" role=""dialog"" aria-labelledby=""myLargeModalLabel"" aria-hidden=""true"">
			<div class=""modal-dialog modal-dialog-scrollable modal-dialog-centered modal-lg"">
				<div class=""modal-content"">
					<div class=""modal-header"">
						<h4 class=""modal-title"" id=""myLargeModalLabel"">Create New Corporate</h4>
						<button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
							<span aria-hidden=""true"">×</span>
						</button>
					</div>
					<div class=""modal-body"">
						<div class=""tb-card-body"">
                            <div class=""tb-padd-lr-30 tb-alert-wrap"">
                                <div class=""tb-height-b25 tb-height-lg-b25""></div>
                                <div class=""form-row"">
                                    <div class=""form-group col-md-6"">
                                        <label for=""inputEmail4"">Status</label>
                                        ");
#nullable restore
#line 27 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Corporate\_Create.cshtml"
                                   Write(Html.DropDownListFor(model => model.Corporate.STATUS, new List<SelectListItem>{
                                                                                  new SelectListItem() { Text = "ACTIVE", Value = "1" },
                                                                                  new SelectListItem() { Text = "DISABLE", Value = "0" }
                                                                              }, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                                    </div>
                                </div>
                                <div class=""form-row"">
                                    <div class=""form-group col-md-6"">
                                        <label for=""inputEmail4"">Corporate Name</label>
                                        ");
#nullable restore
#line 36 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Corporate\_Create.cshtml"
                                   Write(Html.EditorFor(model => model.Corporate.CORPORATENAME, new { htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                    </div>\r\n                                    <div class=\"form-group col-md-6\">\r\n                                        <label for=\"inputEmail4\">Principal Email</label>\r\n                                        ");
#nullable restore
#line 40 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Corporate\_Create.cshtml"
                                   Write(Html.EditorFor(model => model.Corporate.PRINCIPALEMAIL, new { htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                                    </div>
                                </div>
                                <div class=""form-row"">
                                    <div class=""form-group col-md-6"">
                                        <label for=""inputEmail4"">Principal Phone No</label>
                                        ");
#nullable restore
#line 46 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Corporate\_Create.cshtml"
                                   Write(Html.EditorFor(model => model.Corporate.PRINCIPALPHONENO, new { htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                    </div>\r\n                                    <div class=\"form-group col-md-6\">\r\n                                        <label for=\"inputEmail4\">Principal Account No</label>\r\n                                        ");
#nullable restore
#line 50 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Corporate\_Create.cshtml"
                                   Write(Html.EditorFor(model => model.Corporate.PRINCIPALACCOUNTNO, new { htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"

                                    </div>
                                </div>
                                <div class=""form-row"">
                                    <div class=""form-group col-md-6"">
                                        <label for=""inputEmail4"">Interest Rate</label>
                                        ");
#nullable restore
#line 57 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Corporate\_Create.cshtml"
                                   Write(Html.EditorFor(model => model.Corporate.INTERESTRATE, new { htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                                    </div>
                                    <div class=""form-group col-md-6"">
                                        <label for=""inputEmail4"">Available Line of Credit</label>
                                        ");
#nullable restore
#line 61 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Corporate\_Create.cshtml"
                                   Write(Html.EditorFor(model => model.Corporate.AVAILABLELINEOFCREDIT, new { htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"

                                    </div>
                                </div>
                                <div class=""form-row"">
                                    <div class=""form-group col-md-6"">
                                        <label for=""inputEmail4"">Initiator</label>
                                        ");
#nullable restore
#line 68 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Corporate\_Create.cshtml"
                                   Write(Html.EditorFor(model => model.Corporate.CREATEDBYNAME, new { htmlAttributes = new { @class = "form-control", @readonly = "readonly" } }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                    </div>\r\n                                    <div class=\"form-group col-md-6\">\r\n                                        <label for=\"inputEmail4\">Date Initiated</label>\r\n                                        ");
#nullable restore
#line 72 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Corporate\_Create.cshtml"
                                   Write(Html.EditorFor(model => model.Corporate.CREATEDDATE, new { htmlAttributes = new { @class = "form-control", @readonly = "readonly" } }));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                                    </div>
                                </div>
                                <div class=""tb-height-b15 tb-height-lg-b15""></div>
                            </div>
                            </div>
					</div>

					<div class=""modal-footer"">
						<button type=""button"" class=""btn btn-secondary"" data-dismiss=""modal"">Close</button>
						<button type=""submit"" class=""btn btn-primary"">Create Corporate</button>
					</div>
				</div>
			</div>
		</div>

		<script>
		$.ajaxPrefilter(function (options, originalOptions, jqXHR) {
			 jqXHR.setRequestHeader(""__RequestVerificationToken"", '");
#nullable restore
#line 90 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Corporate\_Create.cshtml"
                                                              Write(GetAntiXsrfRequestToken());

#line default
#line hidden
#nullable disable
                WriteLiteral("\');\r\n        });\r\n\t\t</script>\r\n\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n");
        }
        #pragma warning restore 1998
#nullable restore
#line 6 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Corporate\_Create.cshtml"
                   
			public string GetAntiXsrfRequestToken()
			{
				return Xsrf.GetAndStoreTokens(Context).RequestToken;
			}
		

#line default
#line hidden
#nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public Microsoft.AspNetCore.Antiforgery.IAntiforgery Xsrf { get; private set; } = default!;
        #nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CorporateViewModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
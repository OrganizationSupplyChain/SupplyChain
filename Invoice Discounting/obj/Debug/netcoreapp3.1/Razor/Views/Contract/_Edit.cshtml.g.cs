#pragma checksum "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Contract\_Edit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "745d46c2811f9185cec5088c7998686c821bb946"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Contract__Edit), @"mvc.1.0.view", @"/Views/Contract/_Edit.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"745d46c2811f9185cec5088c7998686c821bb946", @"/Views/Contract/_Edit.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5e7e6c2b2e2093347ee78387d906f49a77b633a7", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Contract__Edit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ContractViewModel>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Contract", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "_Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "745d46c2811f9185cec5088c7998686c821bb9464569", async() => {
                WriteLiteral("\r\n\r\n");
                WriteLiteral(@"    <div class=""modal fade"" tabindex=""-1"" role=""dialog"" aria-labelledby=""myLargeModalLabel"" aria-hidden=""true"">
        <div class=""modal-dialog modal-dialog-scrollable modal-dialog-centered modal-lg"">
            <div class=""modal-content"">
                <div class=""modal-header"">
                    <h4 class=""modal-title"" id=""myLargeModalLabel"">Modify Contract Details</h4>
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
                                    <label for=""inputEmail4"">Contract ");
                WriteLiteral("Number</label>\r\n                                    ");
#nullable restore
#line 28 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Contract\_Edit.cshtml"
                               Write(Html.HiddenFor(model=>model.Contract.ID));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                    ");
#nullable restore
#line 29 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Contract\_Edit.cshtml"
                               Write(Html.EditorFor(model => model.Contract.CONTRACTNUMBER, new { htmlAttributes = new { @class = "form-control", @readonly = "readonly" } }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n\r\n                                </div>\r\n                                <div class=\"form-group col-md-6\">\r\n                                    <label for=\"inputEmail4\">PO Number</label>\r\n                                    ");
#nullable restore
#line 34 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Contract\_Edit.cshtml"
                               Write(Html.EditorFor(model => model.Contract.PONUMBER, new { htmlAttributes = new { @class = "form-control", @readonly = "readonly" } }));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                                </div>
                            </div>
                            <div class=""form-row"">
                                <div class=""form-group col-md-6"">
                                    <label for=""inputEmail4"">Contract Name</label>
                                    ");
#nullable restore
#line 40 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Contract\_Edit.cshtml"
                               Write(Html.EditorFor(model => model.Contract.CONTRACTNAME, new { htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                </div>\r\n                                <div class=\"form-group col-md-6\">\r\n                                    <label for=\"inputEmail4\">Quality Specification</label>\r\n                                    ");
#nullable restore
#line 44 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Contract\_Edit.cshtml"
                               Write(Html.TextAreaFor(model => model.Contract.QUALITYSPECIFICATION, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                                </div>
                            </div>
                            <div class=""form-row"">

                                <div class=""form-group col-md-6"">
                                    <label for=""inputEmail4"">Payment Tenor (Days)</label>
                                    ");
#nullable restore
#line 51 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Contract\_Edit.cshtml"
                               Write(Html.EditorFor(model => model.Contract.PAYMENTTENOR, new { htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                </div>\r\n                                <div class=\"form-group col-md-6\">\r\n                                    <label for=\"inputEmail4\">Description</label>\r\n                                    ");
#nullable restore
#line 55 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Contract\_Edit.cshtml"
                               Write(Html.TextAreaFor(model => model.Contract.DESCRIPTION, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                                </div>
                            </div>
                            <div class=""form-row"">
                                <div class=""form-group col-md-6"">
                                    <label for=""inputEmail4"">Timeline (Days)</label>
                                    ");
#nullable restore
#line 61 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Contract\_Edit.cshtml"
                               Write(Html.EditorFor(model => model.Contract.TIMELINEDAYS, new { htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                </div>\r\n                                <div class=\"form-group col-md-6\">\r\n                                    <label for=\"inputEmail4\">Vendor Category</label>\r\n                                    ");
#nullable restore
#line 65 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Contract\_Edit.cshtml"
                               Write(Html.DropDownListFor(model => model.Contract.VENDORCATEGORY, new SelectList(Model.VendorCategory, "Text", "Value"), new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"

                                </div>
                            </div>
                            <div class=""form-row"">
                                <div class=""form-group col-md-6"">
                                    <label for=""inputEmail4"">Other Information</label>
                                    ");
#nullable restore
#line 72 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Contract\_Edit.cshtml"
                               Write(Html.TextAreaFor(model => model.Contract.OTHERINFORMATION, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                </div>\r\n                                <div class=\"form-group col-md-6\">\r\n                                    <label for=\"inputEmail4\">Required Documents</label>\r\n                                    ");
#nullable restore
#line 76 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Contract\_Edit.cshtml"
                               Write(Html.TextAreaFor(model => model.Contract.REQUIREDDOCUMENTS, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                                </div>
                            </div>
                            <div class=""form-row"">
                                <div class=""form-group col-md-6"">
                                    <label for=""inputEmail4"">Modified By</label>
                                    ");
#nullable restore
#line 82 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Contract\_Edit.cshtml"
                               Write(Html.EditorFor(model => model.Contract.LASTMODIFIEDBY, new { htmlAttributes = new { @class = "form-control", @readonly = "readonly" } }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                </div>\r\n                                <div class=\"form-group col-md-6\">\r\n                                    <label for=\"inputEmail4\">Date Modified</label>\r\n                                    ");
#nullable restore
#line 86 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Contract\_Edit.cshtml"
                               Write(Html.EditorFor(model => model.Contract.LASTMODIFIEDDATE, new { htmlAttributes = new { @class = "form-control", @readonly = "readonly" } }));

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
                    <button type=""submit"" class=""btn btn-primary"">Save Changes</button>
                </div>
            </div>
        </div>
    </div>


    <script>
$.ajaxPrefilter(function (options, originalOptions, jqXHR) {
            jqXHR.setRequestHeader(""__RequestVerificationToken"", '");
#nullable restore
#line 105 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Contract\_Edit.cshtml"
                                                             Write(GetAntiXsrfRequestToken());

#line default
#line hidden
#nullable disable
                WriteLiteral("\');\r\n\t});\r\n    </script>\r\n");
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
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n\r\n");
        }
        #pragma warning restore 1998
#nullable restore
#line 6 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Contract\_Edit.cshtml"
               
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ContractViewModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
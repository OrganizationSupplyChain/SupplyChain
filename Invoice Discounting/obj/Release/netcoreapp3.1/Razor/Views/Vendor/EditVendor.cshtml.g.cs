#pragma checksum "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Vendor\EditVendor.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5c4a0b68692754a4d7de546baa08eba568e43fb3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Vendor_EditVendor), @"mvc.1.0.view", @"/Views/Vendor/EditVendor.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5c4a0b68692754a4d7de546baa08eba568e43fb3", @"/Views/Vendor/EditVendor.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5e7e6c2b2e2093347ee78387d906f49a77b633a7", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Vendor_EditVendor : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<VendorViewModel>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/assets/images/file-download-icon.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/assets/images/upload_file_icon.png.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Vendor", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "_EditVendor", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("autocomplete", new global::Microsoft.AspNetCore.Html.HtmlString("off"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Vendor\EditVendor.cshtml"
  
    Layout = "_Layout";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5c4a0b68692754a4d7de546baa08eba568e43fb36083", async() => {
                WriteLiteral("\r\n\r\n");
                WriteLiteral(@"
    <div class=""jumbotron page-wrapper py-5 px-0"">
        <div class=""container-fluid container-fluid-small"">
            <!-- body of bashboard -->

            <div class=""js-add-field"">
                <div class=""row"">
                    <div class=""col-12"">
                        <div class=""card my-card"">
                            <div class=""card-body px-0"">
                                <div class=""header px-4 pb-3 d-flex justify-content-center align-items-center"">
                                    <h5 class=""card-title mb-0"">Vendor Modification</h5>
                                </div>
                                <div class=""row my-5"">
                                    <div class=""col-12 d-flex justify-content-center"">
                                        <ul class=""nav nav-tabs py-1 px-1 mb-4 border-bottom-0 box-tab justify-content-center""
                                            id=""myTab"" role=""tablist"">
                                            <li class");
                WriteLiteral(@"=""nav-item"" role=""presentation"">
                                                <button class=""nav-link px-5 active tab-btn border-0""
                                                        id=""all-vendors-tab"" data-toggle=""tab"" data-target=""#single""
                                                        type=""button"" role=""tab"" aria-controls=""all-vendors""
                                                        aria-selected=""true"">
                                                    <svg width=""14"" height=""14"" viewBox=""0 0 14 14"" fill=""none""
                                                         xmlns=""http://www.w3.org/2000/svg"">
                                                        <path class=""menu-icon"" fill-rule=""evenodd"" clip-rule=""evenodd""
                                                              d=""M2 0H12C13.1 0 14 0.9 14 2V12C14 13.1 13.1 14 12 14H2C0.9 14 0 13.1 0 12V2C0 0.9 0.9 0 2 0ZM7.57143 7.57143H10.4286C10.7429 7.57143 11 7.31429 11 7C11 6.68571 10.7429 6.42857 10.4286 6.42");
                WriteLiteral(@"857H7.57143V3.57143C7.57143 3.25714 7.31429 3 7 3C6.68571 3 6.42857 3.25714 6.42857 3.57143V6.42857H3.57143C3.25714 6.42857 3 6.68571 3 7C3 7.31429 3.25714 7.57143 3.57143 7.57143H6.42857V10.4286C6.42857 10.7429 6.68571 11 7 11C7.31429 11 7.57143 10.7429 7.57143 10.4286V7.57143Z""
                                                              fill=""#9E9FA1"" />
                                                    </svg>
                                                    UPDATE VENDOR
                                                </button>
                                            </li>
                                          


                                        </ul>


                                    </div>
                                </div>

                                <div class=""tab-content container"" id=""myTabContent"">
                                    <div id=""bulk"" class=""tab-pane"">
                                        <div class=""row justify-content-center"">
");
                WriteLiteral(@"


                                            <div class=""col-md-6 form-group"">

                                                <div class=""row mb-3"">
                                                    <div class=""col-12 text-center"">

                                                        <button type=""button"" class=""btn btn-outline-primary blue-outline-btn"">
                                                            Download Template ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "5c4a0b68692754a4d7de546baa08eba568e43fb310103", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                                                        </button>
                                                    </div>
                                                </div>


                                                <div id=""dZUpload"" class=""dropzone ng-dropzone"">
                                                    <div class=""dz-default dz-message"">
                                                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "5c4a0b68692754a4d7de546baa08eba568e43fb311625", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                                                        <h3 class=""mb-3"">
                                                            Drag and drop files here, or <a class=""link blue"" href=""#"">browse</a>
                                                        </h3>
                                                        <span class=""p-2 grey-bg"">CSV, XLS, XLSX</span>
                                                    </div>
                                                </div>

                                                <div class=""row my-5 d-flex justify-content-center"">
                                                    <div class=""col-md-12"">
                                                        <button class=""my-primary primary-btn btn wid100"">Submit</button>
                                                    </div>
                                                </div>

                                            </div>
                                        </div>
          ");
                WriteLiteral(@"                          </div>
                                    <div id=""single"" class=""tab-pane active"">
                                        <div class=""row"">
                                            <div class=""col-md-12 form-group"">
                                                <label>Corporate Name <span class=""red"">*</span></label>
                                                ");
#nullable restore
#line 96 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Vendor\EditVendor.cshtml"
                                           Write(Html.EditorFor(model => model.Vendor.NAME, new { htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                                ");
#nullable restore
#line 97 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Vendor\EditVendor.cshtml"
                                           Write(Html.HiddenFor(model => model.Vendor.ID));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                                            </div>
                                            <div class=""col-md-6 form-group"">
                                                <label>Vendor Status<span class=""red"">*</span></label>

                                                ");
#nullable restore
#line 102 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Vendor\EditVendor.cshtml"
                                           Write(Html.HiddenFor(model => model.Vendor.ID));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                                ");
#nullable restore
#line 103 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Vendor\EditVendor.cshtml"
                                           Write(Html.DropDownListFor(model => model.Vendor.STATUS, new List<SelectListItem>{
                                                    new SelectListItem() { Text = "ACTIVE", Value = "1" },
                                                    new SelectListItem() { Text = "DISABLE", Value = "0" }
                                                }, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                                            </div>

                                            <div class=""col-md-6 form-group"">
                                                <label>Vendor Category<span class=""red"">*</span></label>

                                                ");
#nullable restore
#line 112 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Vendor\EditVendor.cshtml"
                                           Write(Html.EditorFor(model => model.Vendor.CATEGORY, new { htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                                            </div>
                                            <div class=""col-md-6 form-group"">
                                                <label>Vendor's Email<span class=""red"">*</span></label>

                                                ");
#nullable restore
#line 117 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Vendor\EditVendor.cshtml"
                                           Write(Html.EditorFor(model => model.Vendor.EMAIL, new { htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                                            </div>

                                            <div class=""col-md-6 form-group"">
                                                <label>Vendor's Account No<span class=""red"">*</span></label>

                                                ");
#nullable restore
#line 123 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Vendor\EditVendor.cshtml"
                                           Write(Html.EditorFor(model => model.Vendor.ACCOUNTNO, new { htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                                            </div>
                                            <div class=""col-md-6 form-group"">
                                                <label>Vendor's Address<span class=""red"">*</span></label>

                                                ");
#nullable restore
#line 128 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Vendor\EditVendor.cshtml"
                                           Write(Html.EditorFor(model => model.Vendor.ADDRESS, new { htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                                            </div>
                                            <div class=""col-md-6 form-group"">
                                                <label>Vendor Bank<span class=""red"">*</span></label>

                                                ");
#nullable restore
#line 133 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Vendor\EditVendor.cshtml"
                                           Write(Html.EditorFor(model => model.Vendor.BANK, new { htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                                            </div>
                                            <div class=""col-md-6 form-group"">
                                                <label>Vendor TIN/RC<span class=""red"">*</span></label>

                                                ");
#nullable restore
#line 138 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Vendor\EditVendor.cshtml"
                                           Write(Html.EditorFor(model => model.Vendor.TIN_RC, new { htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                                            </div>
                                            <div class=""col-md-6 form-group"">
                                                <label>Service Nature<span class=""red"">*</span></label>

                                                ");
#nullable restore
#line 143 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Vendor\EditVendor.cshtml"
                                           Write(Html.EditorFor(model => model.Vendor.SERVICENATURE, new { htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                                            </div>

                                            <div class=""col-md-6 form-group "">
                                                <label for=""inputEmail4"">Created By</label>
                                                ");
#nullable restore
#line 148 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Vendor\EditVendor.cshtml"
                                           Write(Html.EditorFor(model => model.Vendor.CREATEDBYNAME, new { htmlAttributes = new { @class = "form-control", @readonly = "readonly" } }));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                                            </div>
                                            <div class=""col-md-6 form-group"">
                                                <label for=""inputEmail4"">Date Created</label>
                                                ");
#nullable restore
#line 152 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Vendor\EditVendor.cshtml"
                                           Write(Html.EditorFor(model => model.Vendor.DATECREATED, new { htmlAttributes = new { @class = "form-control", @readonly = "readonly" } }));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                                            </div>

                                        </div>
                                        <div class=""row my-3 d-flex justify-content-center"">
                                            <div class=""col-md-6"">
                                                <button type=""submit"" class=""my-primary primary-btn btn wid100"">Update</button>
                                            </div>
                                        </div>

                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>


                    <!--end of body-->
                </div>
            </div>
        </div>
    </div>









    <script>
$.ajaxPrefilter(function (options, originalOptions, jqXHR) {
            jqXHR.setRequestHeader(""__RequestVerificationToken"", '");
#nullable restore
#line 185 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Vendor\EditVendor.cshtml"
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
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
        }
        #pragma warning restore 1998
#nullable restore
#line 9 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Vendor\EditVendor.cshtml"
               
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<VendorViewModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
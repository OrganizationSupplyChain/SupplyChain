#pragma checksum "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Invoice\RecourseFactoring.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a21aa2ae2c1017229c39837aa2aa05f5e44150d1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Invoice_RecourseFactoring), @"mvc.1.0.view", @"/Views/Invoice/RecourseFactoring.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a21aa2ae2c1017229c39837aa2aa05f5e44150d1", @"/Views/Invoice/RecourseFactoring.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5e7e6c2b2e2093347ee78387d906f49a77b633a7", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Invoice_RecourseFactoring : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<RecourseFactorinViewModel>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/assets/images/file-download-icon.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/assets/images/upload_file_icon.png.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Invoice", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AddNewRecourseFactoring", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Invoice\RecourseFactoring.cshtml"
  
    ViewData["Title"] = "RecourseFactoring";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a21aa2ae2c1017229c39837aa2aa05f5e44150d16175", async() => {
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
                                    <h4 class=""card-title mb-0"">Reverse Factoring Request</h4>
                                    &emsp;
                                    <button style=""background-color:#fe7005; color:white; width:200px"">Available Line: ");
#nullable restore
#line 20 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Invoice\RecourseFactoring.cshtml"
                                                                                                                  Write(Model.CorporateAvailableLimit);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</button>
                                </div>
                                <div class=""row my-5"">
                                    <div class=""col-12 d-flex justify-content-center"">
                                        <ul class=""nav nav-tabs py-1 px-1 mb-4 border-bottom-0 box-tab justify-content-center""
                                            id=""myTab"" role=""tablist"">
                                            <li class=""nav-item"" role=""presentation"">
                                                <button class=""nav-link px-5 active tab-btn border-0""
                                                        id=""recourse-single-tab"" data-toggle=""tab"" data-target=""#single""
                                                        type=""button"" role=""tab"" aria-controls=""recourse-single""
                                                        aria-selected=""true"">
                                                    <svg width=""14"" height=""14"" viewBox=""0 0 14 14"" fill=""none""
           ");
                WriteLiteral(@"                                              xmlns=""http://www.w3.org/2000/svg"">
                                                        <path class=""menu-icon"" fill-rule=""evenodd"" clip-rule=""evenodd""
                                                              d=""M2 0H12C13.1 0 14 0.9 14 2V12C14 13.1 13.1 14 12 14H2C0.9 14 0 13.1 0 12V2C0 0.9 0.9 0 2 0ZM7.57143 7.57143H10.4286C10.7429 7.57143 11 7.31429 11 7C11 6.68571 10.7429 6.42857 10.4286 6.42857H7.57143V3.57143C7.57143 3.25714 7.31429 3 7 3C6.68571 3 6.42857 3.25714 6.42857 3.57143V6.42857H3.57143C3.25714 6.42857 3 6.68571 3 7C3 7.31429 3.25714 7.57143 3.57143 7.57143H6.42857V10.4286C6.42857 10.7429 6.68571 11 7 11C7.31429 11 7.57143 10.7429 7.57143 10.4286V7.57143Z""
                                                              fill=""#9E9FA1"" />
                                                    </svg>
                                                    Single Request
                                                </button>
                  ");
                WriteLiteral(@"                          </li>
                                            <li class=""nav-item  "" role=""presentation"">
                                                <button class=""nav-link px-5 tab-btn border-0"" id=""recourse-bulk-tab""
                                                        data-toggle=""tab"" data-target=""#bulk"" type=""button"" role=""tab""
                                                        aria-controls=""recourse-bulk"" aria-selected=""false"">

                                                    <svg width=""14"" height=""20"" viewBox=""0 0 14 20"" fill=""none""
                                                         xmlns=""http://www.w3.org/2000/svg"">
                                                        <path class=""menu-icon"" fill-rule=""evenodd"" clip-rule=""evenodd""
                                                              d=""M2 6H12C13.1 6 14 6.9 14 8V18C14 19.1 13.1 20 12 20H2C0.9 20 0 19.1 0 18V8C0 6.9 0.9 6 2 6ZM7.57143 13.5714H10.4286C10.7429 13.5714 11 13.3143 11 13C11 12.685");
                WriteLiteral(@"7 10.7429 12.4286 10.4286 12.4286H7.57143V9.57143C7.57143 9.25714 7.31429 9 7 9C6.68571 9 6.42857 9.25714 6.42857 9.57143V12.4286H3.57143C3.25714 12.4286 3 12.6857 3 13C3 13.3143 3.25714 13.5714 3.57143 13.5714H6.42857V16.4286C6.42857 16.7429 6.68571 17 7 17C7.31429 17 7.57143 16.7429 7.57143 16.4286V13.5714Z""
                                                              fill=""#9E9FA1"" />
                                                        <path class=""menu-icon""
                                                              d=""M1 4.5H13C13 3.67 12.33 3 11.5 3H2.5C1.67 3 1 3.67 1 4.5Z""
                                                              fill=""#9E9FA1"" />
                                                        <path class=""menu-icon""
                                                              d=""M2 1.5H12C12 0.67 11.33 0 10.5 0H3.5C2.67 0 2 0.67 2 1.5Z""
                                                              fill=""#9E9FA1"" />
                                                    </sv");
                WriteLiteral(@"g>

                                                    Bulk Request
                                                </button>
                                            </li>


                                        </ul>


                                    </div>
                                </div>

                                <div class=""tab-content container"" id=""myTabContent"">
                                    <div id=""bulk"" class=""tab-pane"">
                                        <div class=""row justify-content-center"">
                                           <div class=""col-md-6 form-group"">

                                                <div class=""row mb-3"">
                                                    <div class=""col-12 text-center"">

                                                        <button type=""button"" class=""btn btn-outline-primary blue-outline-btn"">
                                                            Download Template ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "a21aa2ae2c1017229c39837aa2aa05f5e44150d112983", async() => {
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
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "a21aa2ae2c1017229c39837aa2aa05f5e44150d114505", async() => {
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
                                            <div class=""col-md-6 form-group"">
                                                <label>Select Invoice</label><span class=""red"">*</span>
                                                ");
#nullable restore
#line 107 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Invoice\RecourseFactoring.cshtml"
                                           Write(Html.DropDownListFor(model => model.RecourseFDetails.invoicenumber, new SelectList(Model.InvoiceList, "Value", "Text"), "--- Select Invoice ---", new { @class = "form-control", @id = "ddlinvoice" }));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"

                                            </div>
                                             <div class=""col-md-6 form-group"">
                                                <label>Contract Number <span class=""red"">*</span></label>
                                                ");
#nullable restore
#line 112 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Invoice\RecourseFactoring.cshtml"
                                           Write(Html.EditorFor(model => model.ContractNumber, new { htmlAttributes = new { @class = "form-control", @id = "contractnumber", @readonly = "readonly" } }));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"

                                            </div>

                                            <div class=""col-md-6 form-group"">
                                                <label>Contract Name<span class=""red"">*</span></label>
                                                ");
#nullable restore
#line 118 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Invoice\RecourseFactoring.cshtml"
                                           Write(Html.EditorFor(model => model.ContractName, new { htmlAttributes = new { @class = "form-control", @id = "contractname", @readonly = "readonly" } }));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                                            </div>
                                            <div class=""col-md-6 form-group"">
                                                <label>Vendor Name <span class=""red"">*</span></label>
                                                ");
#nullable restore
#line 122 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Invoice\RecourseFactoring.cshtml"
                                           Write(Html.EditorFor(model => model.RecourseFDetails.vendorname, new { htmlAttributes = new { @class = "form-control", @id = "vendorname", @readonly = "readonly" } }));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"

                                            </div>

                                            <div class=""col-md-6 form-group"">
                                                <label>Vendor's Email Address<span class=""red"">*</span></label>
                                                ");
#nullable restore
#line 128 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Invoice\RecourseFactoring.cshtml"
                                           Write(Html.EditorFor(model => model.RecourseFDetails.vendoremail, new { htmlAttributes = new { @class = "form-control", @id = "vendoremail", @readonly = "readonly" } }));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                                            </div>

                                            <div class=""col-md-6 form-group"">
                                                <label>Vendor's Account Number<span class=""red"">*</span></label>

                                                ");
#nullable restore
#line 134 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Invoice\RecourseFactoring.cshtml"
                                           Write(Html.EditorFor(model => model.RecourseFDetails.vendoraccountno, new { htmlAttributes = new { @class = "form-control", @id = "vendoraccountno" } }));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                                            </div>

                                            <div class=""col-md-6 form-group"">
                                                <label>Vendor's Account Name<span class=""red"">*</span></label>

                                                ");
#nullable restore
#line 140 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Invoice\RecourseFactoring.cshtml"
                                           Write(Html.EditorFor(model => model.RecourseFDetails.vendoraccountname, new { htmlAttributes = new { @class = "form-control", @id = "vendoraccountname", @readonly = "readonly" } }));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                                            </div>

                                            <div class=""col-md-6 form-group"">
                                                <label>Amount<span class=""red"">*</span></label>
                                                ");
#nullable restore
#line 145 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Invoice\RecourseFactoring.cshtml"
                                           Write(Html.HiddenFor(model => model.InvoiceAmount, new { @id = "invoiceamount"}));

#line default
#line hidden
#nullable disable
                WriteLiteral(" \r\n                                                ");
#nullable restore
#line 146 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Invoice\RecourseFactoring.cshtml"
                                           Write(Html.EditorFor(model => model.totalamount, new { htmlAttributes = new { @class = "form-control", @id = "totalamt" } }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n\r\n");
                WriteLiteral(@"                                            </div>
                                            <div class=""col-md-6 form-group"">
                                                <label>Credit Vendor On<span class=""red"">*</span></label>
                                                ");
#nullable restore
#line 152 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Invoice\RecourseFactoring.cshtml"
                                           Write(Html.EditorFor(model => model.DisbursementDate, new { htmlAttributes = new { @class = "form-control", @id = "disbursementdate", @readonly = "readonly" } }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n");
                WriteLiteral(@"                                            </div>
                                            <div class=""col-md-6 form-group"">
                                                <label>Maturity Period (Days)<span class=""red"">*</span></label>

                                                ");
#nullable restore
#line 158 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Invoice\RecourseFactoring.cshtml"
                                           Write(Html.EditorFor(model => model.RecourseFDetails.maturityperiod, new { htmlAttributes = new { @class = "form-control", @id = "maturityperiod", @readonly = "readonly" } }));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                                            </div>
                                            <div class=""col-md-6 form-group"">
                                                <label>Account to Debit at Maturity<span class=""red"">*</span></label>

                                                ");
#nullable restore
#line 163 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Invoice\RecourseFactoring.cshtml"
                                           Write(Html.EditorFor(model => model.CorporateLoanDetails.accountnumber, new { htmlAttributes = new { @class = "form-control", @id="corporateacctno" } }));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                                            </div>
                                            <div class=""col-md-6 form-group"">
                                                <label>Account Name to Debit at Maturity<span class=""red"">*</span></label>

                                                ");
#nullable restore
#line 168 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Invoice\RecourseFactoring.cshtml"
                                           Write(Html.EditorFor(model => model.CorporateLoanDetails.accountname, new { htmlAttributes = new { @class = "form-control", @id = "corporateacctname", @readonly = "readonly" } }));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                                            </div>
                                        </div>

                                        <div class=""row my-3 d-flex justify-content-center"">
                                            <div class=""col-md-6"">
                                                <button type=""submit"" class=""my-primary primary-btn btn wid100"">Submit</button>
                                            </div>
                                        </div>
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

   
");
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
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
<script>
     
    $('#disbursementdate').on('change', function () {
        var dd = $('#disbursementdate').val();
        var currentdate = new Date();
        var currentdateUTC = new Date().toISOString();
        var currentdateUTCYear = new Date().toISOString().substring(0,4);
        var currentdateUTCMonth = new Date().toISOString().substring(5, 7);
        var currentdateUTCDay = new Date().toISOString().substring(8,10);
       // var dateOnly = $.format.date('2011-08-31T20:01:32.000Z', ""dd-MM-yyyy""));
       // var currentdateUTCDate = new Date().toISOString().getDate();
       
        if(dd != ''){
            var disbursedate = new Date(dd);
            var disbursedateUTC = new Date(dd).toISOString();

            if(disbursedateUTC.substring(0,4) < currentdateUTC.substring(0,4) || disbursedateUTC.substring(5,7) < currentdateUTC.substring(5,7)
                || disbursedateUTC.substring(8,10) < currentdateUTC.substring(8,10)){
                swal(""Invalid Disbursement Date"",");
                WriteLiteral(@" ""Disbursement date cannot be less than today"", ""error"");
                $('#disbursementdate').val('');
            }
        }
    });

    $('#chkrequestdisc').on('change', function () {
        console.log(""discounting"");
        if (!this.checked) {
            $('#accountname').val('');
            $('#eligibleamt').val('');
            $('#interest').val('');
            $('#fees').val('');
            $('#bankname').val('');

            $('#pnldiscounting').hide();

        } else {
            var totalamt = $(""#totalamount"").val();
            var accountno = $(""#accountno"").val
            if (accountno == '' || totalamt == 0) {
                alert(""Account number and Total Amount are required to request for discouting"");
                this.checked = false;
            }
            else {
                $.ajax({
                    data: $('#createInvoiceForm').serialize(),
                    url: '/Invoice/ValidateInvoiceDiscounting',
                    type: ");
                WriteLiteral(@"'POST',
                    success: function (result) {
                        if (result == null) {
                            $('#accountname').val('');
                            $('#eligibleamt').val('');
                            $('#interest').val('');
                            $('#fees').val('');
                            $('#bankname').val('');
                            this.checked = false;
                            $('#pnldiscounting').hide();
                            alert(""Invalid account, hence unable to initiate loan request"");
                            return false;
                        } else {
                            var jsonObj = jQuery.parseJSON(result);
                            $('#accountname').val(jsonObj.AccountName);
                            $('#eligibleamt').val(jsonObj.EligibleAmount.toFixed(2));
                            $('#interest').val(jsonObj.Interest.toFixed(2));
                            $('#fees').val(jsonObj.Fees.toFixed(");
                WriteLiteral(@"2));
                            $('#bankname').val(""ACCESS BANK"");

                            $('#pnldiscounting').show();

                        }

                    }
                });
            }
        }
    });

    $(""#ddlinvoice"").on('change', function () {

        var invoiceId = $(""#ddlinvoice"").val();
        console.log(""Invoice ID :: "" + invoiceId);

        if (invoiceId != null && invoiceId != '') {

            $.ajax({
                data: { invoiceId: invoiceId },
                url: '/Invoice/GetInvoiceDetailsByID',
                type: 'GET',
                success: function (result) {
                    if (result == null) {
                        $('#vendorname').val('');
                        $('#vendoremail').val('');
                        $('#vendoraccountno').val('');
                        $('#vendoraccountname').val('');
                        $('#contractnumber').val('');
                        $('#contractname').val('');
  ");
                WriteLiteral(@"                      $('#totalamt').val('');
                        $('#invoiceamount').val('');
                        $('#maturityperiod').val('');

                        alert(""Unable to fetch invoice details"");
                        return false;
                    } else {
                        var jsonObj = jQuery.parseJSON(result);
                        $('#vendorname').val(jsonObj.ContractInvoice.vendorname);
                        $('#vendoremail').val(jsonObj.ContractInvoice.vendoremail);
                        $('#vendoraccountno').val(jsonObj.ContractInvoice.accountnumber);
                        $('#vendoraccountname').val(jsonObj.ContractInvoice.accountname);
                        $('#contractnumber').val(jsonObj.ContractNumber);
                        $('#contractname').val(jsonObj.ContractName);
                        $('#totalamt').val(jsonObj.ContractInvoice.totalincludingvat);
                        $('#invoiceamount').val(jsonObj.ContractInvoice.totalincl");
                WriteLiteral(@"udingvat);
                        $('#maturityperiod').val(jsonObj.PaymentTenor);
                    }

                }
            });
        } else {
            $('#vendorname').val('');
            $('#vendoremail').val('');
            $('#vendoraccountno').val('');
            $('#vendoraccountname').val('');
        }        
    });

    $(""#vendoraccountno"").on('change', function () {
        
        var accountNo = $(""#vendoraccountno"").val();

        if (accountNo != '') {

            $.ajax({
                data: { accountNo: accountNo },
                url: '/Invoice/GetAccountDetailsByAccountNo',
                type: 'GET',
                success: function (result) {
                    if (result == null) {

                        $('#vendoraccountname').val('');

                        swal(""Invalid Account"", ""Unable to fetch account details. Kindly verify the account number is a valid Access Bank account"", ""error"");
                        return fa");
                WriteLiteral(@"lse;
                    } else {
                        var jsonObj = jQuery.parseJSON(result);

                        if (jsonObj.accountName == null || jsonObj.accountName == '') {

                            $('#vendoraccountname').val('');
                            $('#vendoraccountno').val('');
                            swal(""Invalid Account"", ""Unable to fetch account details. Kindly verify the account number is a valid Access Bank account"", ""error"");
                            return false;

                        } else {
                            $('#vendoraccountname').val(jsonObj.accountName);
                        }
                    }
                }
            });
        } else {

            $('#vendoraccountname').val('');
        }        
    });

    $(""#corporateacctno"").on('change', function () {

        var accountNo = $(""#corporateacctno"").val();

        if (accountNo != '') {

            $.ajax({
                data: { accountNo: ac");
                WriteLiteral(@"countNo },
                url: '/Invoice/GetAccountDetailsByAccountNo',
                type: 'GET',
                success: function (result) {
                    if (result == null) {

                        $('#corporateacctname').val('');
                        $('#corporateacctno').val('');
                        swal(""Invalid Account"", ""Unable to fetch account details. Kindly verify the account number is a valid Access Bank account"", ""error"");
                        return false;
                    } else {
                       
                        var jsonObj = jQuery.parseJSON(result);
                        if (jsonObj.accountName == null || jsonObj.accountName == '') {

                            $('#corporateacctname').val('');
                            $('#corporateacctno').val('');
                            swal(""Invalid Account"", ""Unable to fetch account details. Kindly verify the account number is a valid Access Bank account"", ""error"");
                    ");
                WriteLiteral(@"        return false;

                        } else {
                            $('#corporateacctname').val(jsonObj.accountName);
                        }
                    }
                }
            });
        } else {

            $('#corporateacctname').val('');
        } 
        return true;
    });
    $(""#totalamt"").on('change', function () {
        var totalamt = $(""#totalamt"").val().replace(/,/g, """");
        var contractamt =  $('#invoiceamount').val();
        if (+totalamt > ");
#nullable restore
#line 400 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Invoice\RecourseFactoring.cshtml"
                   Write(Model.CorporateAvailableLimit);

#line default
#line hidden
#nullable disable
                WriteLiteral(@") {
            swal(""Invalid Amount"", ""The total amount requested cannot exceed the Corporate's available Line of Credit"", ""error"");
            $(""#totalamt"").val('');
            return false;
        } else if(+totalamt > contractamt) {
            swal(""Invalid Amount"", ""The total amount requested cannot exceed the invoice amount"", ""error"");
            $(""#totalamt"").val('');
            return false;
        } else {

            var formattedAmt = addCommas(totalamt);
            $(""#totalamt"").val(formattedAmt);
        }
    });
   
    function addCommas(x) {
        var newX = x.replace("","", """");
        var parts = newX.toString().split(""."");
        parts[0] = parts[0].replace(/\B(?=(\d{3})+(?!\d))/g, "","");
        return parts.join(""."");
    }
</script>
 ");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<RecourseFactorinViewModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
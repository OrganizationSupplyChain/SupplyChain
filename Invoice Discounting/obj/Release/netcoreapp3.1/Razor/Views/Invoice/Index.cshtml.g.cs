#pragma checksum "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Invoice\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f595f3d605fe0fb138b9d2a390f46e290f50b30c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Invoice_Index), @"mvc.1.0.view", @"/Views/Invoice/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f595f3d605fe0fb138b9d2a390f46e290f50b30c", @"/Views/Invoice/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5e7e6c2b2e2093347ee78387d906f49a77b633a7", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Invoice_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<InvoiceVendorViewModel>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/assets/images/plus-icon.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/assets/images/edit.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("mr-2"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#nullable restore
#line 2 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Invoice\Index.cshtml"
  
    ViewData["Title"] = "Vendor Invoice";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"container-fluid\">\r\n    <div class=\"row\">\r\n        <div class=\"col-12 d-flex justify-content-between\">\r\n            <h3 class=\"page-title\">Invoices</h3>\r\n            <p>");
#nullable restore
#line 10 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Invoice\Index.cshtml"
          Write(DateTime.UtcNow.ToShortDateString());

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>

        </div>
    </div>

    <div class=""row my-2"">
        <div class=""col-12"">
            <div class=""col-12 d-flex justify-content-between align-items-center"">

                <ul class=""nav nav-tabs mb-4 border-bottom-0"" id=""myTab"" role=""tablist"">
                    <li class=""nav-item"" role=""presentation"">
                        <button class=""nav-link active tab-btn "" id=""invoices-tab"" data-toggle=""tab""
                                data-target=""#invoiceDet"" type=""button"" role=""tab"" aria-controls=""invoices""
                                aria-selected=""true"">
                            Invoices
                        </button>
                    </li>
                    <li class=""nav-item"" role=""presentation"">
                        <button class=""nav-link tab-btn"" id=""invoice-discounting-tab"" data-toggle=""tab""
                                data-target=""#invoiceDiscounting"" type=""button"" role=""tab"" aria-controls=""invoice-discounting""
                           ");
            WriteLiteral(@"     aria-selected=""false"">
                            Invoice Discounting Requests
                        </button>
                    </li>
                </ul>
                <div class=""row mb-4 border-bottom-0"">
                    <div id=""dvInvoiceSearch"" class=""search-group"">
                        <input type=""text"" id=""txtSearch"" style=""width: 300px;"" placeholder=""search"" class=""form-control pl-5""
                               aria-label=""Text input with checkbox"">
                        <i class=""fa fa-search""></i>
                    </div>
                    <div id=""dvInvoiceDiscSearch"" class=""search-group"" style=""display:none"">
                        <input type=""text"" id=""txtSearchInvoiceDisc"" style=""width: 300px;"" placeholder=""search"" class=""form-control pl-5""
                               aria-label=""Text input with checkbox"">
                        <i class=""fa fa-search""></i>
                    </div>
                    <div id=""dvSpaceID"">&emsp;</div>
      ");
            WriteLiteral("              <div>\r\n                        <button type=\"button\" class=\"btn btn-outline-primary blue-outline-btn\" id=\"lnkCreate\">\r\n                            Create New ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "f595f3d605fe0fb138b9d2a390f46e290f50b30c7738", async() => {
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
            WriteLiteral("\r\n                        </button>\r\n\r\n");
            WriteLiteral(@"                    </div>
                    
                </div>
            </div>


                <div class=""tab-content"" id=""myTabContent"">
                    <div class=""card my-card tab-pane active "" id=""invoiceDet"">
                        <div class=""card-body px-0"">
                            <div class=""header px-4 pb-3 d-flex justify-content-between align-items-center"">
                                <h5 class=""card-title mb-0"">Invoice List</h5>

                            </div>

                            <div class=""notif-wrapper p-4 notif-card "" style=""height: 55vh;"">
                                <table id=""invoiceTable"" class=""table"" style=""width:100%"">
                                    <thead style=""text-align:left"">
                                        <tr>
                                            <th>S/N</th>
                                            <th>Project Name</th>
                                            <th>Invoice No</th>
         ");
            WriteLiteral(@"                                   <th>Amount</th>
                                            <th>Contract No</th>
                                            <th>Client(Corporate)</th>
                                            <th>Date Created</th>
                                            <th>Status</th>
                                            <th>Action</th>
                                        </tr>
                                    </thead>
                                    <tbody>
");
#nullable restore
#line 85 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Invoice\Index.cshtml"
                                           int i = 1; 

#line default
#line hidden
#nullable disable
#nullable restore
#line 86 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Invoice\Index.cshtml"
                                         if (Model.InvoiceDetails == null)
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <tr>\r\n                                                <td colspan=\"8\">No Record Found</td>\r\n                                            </tr>\r\n");
#nullable restore
#line 91 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Invoice\Index.cshtml"
                                        }
                                        else
                                        {
                                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 94 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Invoice\Index.cshtml"
                                             foreach (var item in Model.InvoiceDetails)
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                <tr>\r\n                                                    <td>\r\n                                                        <label> ");
#nullable restore
#line 98 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Invoice\Index.cshtml"
                                                           Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </label>\r\n");
#nullable restore
#line 99 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Invoice\Index.cshtml"
                                                           i++; 

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    </td>\r\n                                                    <td>\r\n                                                        ");
#nullable restore
#line 102 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Invoice\Index.cshtml"
                                                   Write(Html.DisplayFor(modelItem => item.projectname));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                    </td>\r\n                                                    <td>\r\n                                                        ");
#nullable restore
#line 105 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Invoice\Index.cshtml"
                                                   Write(Html.ActionLink(item.invoicenumber, "GetVendorInvoiceModal", new { invoiceId = item.invoiceid }, new { @class = "link blue", @id = "lnkinvoice" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                    </td>\r\n                                                    <td>\r\n                                                        ");
#nullable restore
#line 108 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Invoice\Index.cshtml"
                                                   Write(Html.DisplayFor(modelItem => item.totalincludingvat));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                    </td>\r\n                                                    <td>\r\n                                                        ");
#nullable restore
#line 111 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Invoice\Index.cshtml"
                                                   Write(Html.DisplayFor(modelItem => item.contractnumber));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                    </td>\r\n                                                    <td>\r\n                                                        ");
#nullable restore
#line 114 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Invoice\Index.cshtml"
                                                   Write(Html.DisplayFor(modelItem => item.CorporateName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                    </td>\r\n                                                    <td>\r\n                                                        ");
#nullable restore
#line 117 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Invoice\Index.cshtml"
                                                   Write(Html.DisplayFor(modelItem => item.invoicedate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                    </td>\r\n\r\n                                                    <td>\r\n");
#nullable restore
#line 121 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Invoice\Index.cshtml"
                                                         if (item.invoicestatus == "REJECTED")
                                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                                            <div class=""status alert alert-danger mb-0 py-1"" role=""alert"">
                                                                <label style=""width:80px"">Rejected</label>
                                                            </div>
");
#nullable restore
#line 126 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Invoice\Index.cshtml"
                                                        }
                                                        else if (item.invoicestatus == "COMPLETED")
                                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                                            <div class=""status alert alert-info mb-0 py-1"" role=""alert"">
                                                                <label style=""width:80px"">Completed</label>
                                                            </div>
");
#nullable restore
#line 132 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Invoice\Index.cshtml"
                                                        }
                                                        else if (item.invoicestatus == "PENDING")
                                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                                            <div class=""status alert alert-warning mb-0 py-1"" role=""alert"">
                                                                <label style=""width:80px"">Pending</label>
                                                            </div>
");
#nullable restore
#line 138 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Invoice\Index.cshtml"
                                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    </td>\r\n                                                    <td>\r\n");
#nullable restore
#line 141 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Invoice\Index.cshtml"
                                                         if (item.invoicestatus == "REJECTED")
                                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                            <div class=\"d-flex justify-content-around\">\r\n                                                                <a");
            BeginWriteAttribute("href", " href=\"", 8815, "\"", 8890, 1);
#nullable restore
#line 144 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Invoice\Index.cshtml"
WriteAttributeValue("", 8822, Url.Action("ModifyInvoice", "Invoice", new { id = item.invoiceid }), 8822, 68, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" title=\"Modify Invoice\">\r\n                                                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "f595f3d605fe0fb138b9d2a390f46e290f50b30c19925", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                                                </a>\r\n                                                            </div>\r\n");
#nullable restore
#line 148 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Invoice\Index.cshtml"
                                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    </td>\r\n                                                </tr>\r\n");
#nullable restore
#line 151 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Invoice\Index.cshtml"
                                            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 151 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Invoice\Index.cshtml"
                                             
                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                    </tbody>
                                </table>

                            </div>

                        </div>
                    </div>

                    <div class=""card my-card"" id=""invoiceDiscounting"">
                        <div class=""card-body px-0"">
                            <div class=""header px-4 pb-3 d-flex justify-content-between align-items-center"">
                                <h4 class=""card-title mb-0"">
                                    Invoice Discounting Requests
                                </h4>

                            </div>
                            <div class=""notif-wrapper p-4 notif-card "" style=""height: 55vh;"">
                                <table id=""invoicediscountingTable"" class=""table  example"" style=""width:100%"">
                                    <thead style=""text-align:left"">
                                        <tr>
                                            <th>S/N</th>
             ");
            WriteLiteral(@"                               <th>Invoice Number</th>
                                            <th>Discounting Amount</th>
                                            <th>Disbursement Date</th>
                                            <th>Disbursement Status</th>
                                            <th>Repayment Date</th>
                                            <th>Repayment Status</th>
                                        </tr>
                                    </thead>
                                    <tbody>
");
#nullable restore
#line 183 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Invoice\Index.cshtml"
                                           int j = 1; 

#line default
#line hidden
#nullable disable
#nullable restore
#line 184 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Invoice\Index.cshtml"
                                         if (Model.InvoiceDiscounting == null)
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <tr>\r\n                                            \r\n                                            <td colspan=\"8\">No Record Found</td>\r\n                                        </tr>\r\n");
#nullable restore
#line 190 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Invoice\Index.cshtml"
                                        }
                                        else
                                        {
                                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 193 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Invoice\Index.cshtml"
                                             foreach (var item in Model.InvoiceDiscounting)
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                <tr>\r\n                                                    <td>\r\n                                                        <label> ");
#nullable restore
#line 197 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Invoice\Index.cshtml"
                                                           Write(j);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </label>\r\n");
#nullable restore
#line 198 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Invoice\Index.cshtml"
                                                           j++; 

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    </td>\r\n                                                    <td>\r\n                                                        ");
#nullable restore
#line 201 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Invoice\Index.cshtml"
                                                   Write(Html.ActionLink(item.invoicenumber, "GetInvoiceDiscountingById", new { invoiceId = item.invoiceid }, new { @class = "link blue", @id = "lnkinvdisc" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                    </td>\r\n");
            WriteLiteral("                                                    <td>\r\n                                                        ");
#nullable restore
#line 207 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Invoice\Index.cshtml"
                                                   Write(Html.DisplayFor(modelItem => item.requestedamount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                    </td>\r\n                                                    <td>\r\n                                                        ");
#nullable restore
#line 210 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Invoice\Index.cshtml"
                                                   Write(Html.DisplayFor(modelItem => item.disbursementDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                    </td>\r\n                                                    <td>\r\n");
#nullable restore
#line 213 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Invoice\Index.cshtml"
                                                         if (item.FundsDisbursed == 1)
                                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                                            <div class=""status alert alert-success mb-0 py-1"" role=""alert"">
                                                                <label>Disbursed</label>
                                                            </div>
");
#nullable restore
#line 218 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Invoice\Index.cshtml"
                                                        }
                                                        else
                                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                                            <div class=""status alert alert-warning mb-0 py-1"" role=""alert"">
                                                                <label>Pending</label>
                                                            </div>
");
#nullable restore
#line 224 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Invoice\Index.cshtml"
                                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    </td>\r\n                                                    <td>\r\n                                                        ");
#nullable restore
#line 227 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Invoice\Index.cshtml"
                                                   Write(Html.DisplayFor(modelItem => item.RepaymentDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                    </td>\r\n                                                    <td>\r\n");
#nullable restore
#line 230 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Invoice\Index.cshtml"
                                                         if (item.LoanRepaid == 1)
                                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                                            <div class=""status alert alert-success mb-0 py-1"" role=""alert"">
                                                                <label>Completed</label>
                                                            </div>
");
#nullable restore
#line 235 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Invoice\Index.cshtml"
                                                        }
                                                        else
                                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                                            <div class=""status alert alert-warning mb-0 py-1"" role=""alert"">
                                                                <label>Pending</label>
                                                            </div>
");
#nullable restore
#line 241 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Invoice\Index.cshtml"
                                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    </td>\r\n                                                </tr>\r\n");
#nullable restore
#line 244 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Invoice\Index.cshtml"
                                            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 244 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Invoice\Index.cshtml"
                                             
                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>

                </div>
            </div>
    </div>  
</div>

    <div id=""cmodal""></div>
");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
        <script>

            $(document).ready(function () {
                $('#invoiceTable').DataTable({
                    dom: 'lrtip',
                    order: [],
                    paging: true,
                    info: true,
                    buttons: [
                        {
                            extend: 'excel',
                            className: 'excel',
                            text: '<i class=""fas fa-file-excel""></i>',
                            footer: true,
                            titleAttr: 'Excel'
                        },
                        {
                            extend: 'pdf',
                            text: '<i class=""fas fa-file-pdf""></i>',
                            titleAttr: 'PDF'
                        }
                    ]
                });

                $('#invoicediscountingTable').DataTable({
                    dom: 'lrtip',
                    order: [],
                    paging: true,
        ");
                WriteLiteral(@"            info: true
                });
            });
            $(""a.link"").on('click', function () {
                $.ajax({
                    url: this.href,
                    type: 'Get',
                    cache: true,
                    success: function (result) {
                        console.log(""Result is :: "" + result);
                        $('#cmodal').html(result).find('.modal').modal({
                            show: true
                        });
                    }
                });
                return false;
            });
            $('#txtSearch').on('keyup', function () {
                var searchTxt = $(""#txtSearch"").val();
                $('#invoiceTable').DataTable().search(searchTxt).draw();
            });
            $('#txtSearchInvoiceDisc').on('keyup', function () {

                var searchTxt = $(""#txtSearchInvoiceDisc"").val();
                $('#invoicediscountingTable').DataTable().search(searchTxt).draw();
         ");
                WriteLiteral(@"   });
            $('button[data-toggle=""tab""]').on('shown.bs.tab', function (e) {

                var target = $(e.target).attr(""data-target""); // activated tab
                if (target == ""#invoiceDet"") {
                    $(""#dvInvoiceSearch"").show();
                   // $(""#dvSpaceInv"").show();
                    $(""#dvInvoiceDiscSearch"").hide();
                   // $(""#dvSpaceID"").hide();
                 } else {
                    $(""#dvInvoiceSearch"").hide();
                   // $(""#dvSpaceInv"").hide();
                    $(""#dvInvoiceDiscSearch"").show();
                   //$(""#dvSpaceID"").hide();
                }
            });

            $(""#lnkCreate"").on('click', function () {
                window.location.href = '");
#nullable restore
#line 331 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Invoice\Index.cshtml"
                                   Write(Url.Action("CreateExternalInvoice", "Invoice"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\';           \r\n            });\r\n        </script>\r\n    ");
            }
            );
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<InvoiceVendorViewModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
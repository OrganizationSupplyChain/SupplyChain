#pragma checksum "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\ContractResponse\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0ef87fbbab897409f36a52bffd173d52ea4b7524"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ContractResponse_Index), @"mvc.1.0.view", @"/Views/ContractResponse/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0ef87fbbab897409f36a52bffd173d52ea4b7524", @"/Views/ContractResponse/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5e7e6c2b2e2093347ee78387d906f49a77b633a7", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_ContractResponse_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<VendorContractListModel>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\ContractResponse\Index.cshtml"
  
    ViewData["Title"] = "Vendor Contract";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"container-fluid\">\r\n    <div class=\"row\">\r\n        <div class=\"col-12 d-flex justify-content-between\">\r\n            <h3 class=\"page-title\">Contracts</h3>\r\n            <p>");
#nullable restore
#line 10 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\ContractResponse\Index.cshtml"
          Write(DateTime.UtcNow.ToShortDateString());

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>

        </div>
    </div>

    <div class=""row mt-4"">
        <div class=""col-12 d-flex justify-content-between align-items-center"">
            <div class=""search-group"">
                <input type=""text"" style=""width: 300px;"" placeholder=""search"" id=""txtSearch"" class=""form-control pl-5""
                       aria-label=""Text input with checkbox"">
                <i class=""fa fa-search""></i>
            </div>

");
            WriteLiteral(@"        </div>
    </div>

    <div class=""row my-5"">
        <div class=""col-12"">
            <div class=""card my-card"">
                <div class=""card-body px-0"">
                    <div class=""header px-4 pb-3 d-flex justify-content-between align-items-center"">
                        <h5 class=""card-title mb-0"">Contracts List</h5>

                    </div>

                    <div class=""notif-wrapper p-4 notif-card "" style=""height: 55vh;"">
                        <table id=""contractTable"" class=""table"" style=""width:100%"">
                            <thead style=""text-align:left"">
                                <tr>
                                    <th>S/N</th>
                                    <th>Contract No</th>
                                    <th>Description</th>
                                    <th>Contract Amount</th>
                                    <th>Payment Tenor</th>
                                    <th>PO Number</th>
                            ");
            WriteLiteral("        <th>Client</th>\r\n                                    <th>Date Created</th>\r\n                                    <th>Status</th>\r\n                                </tr>\r\n                            </thead>\r\n                            <tbody>\r\n");
#nullable restore
#line 54 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\ContractResponse\Index.cshtml"
                                   int i = 1; 

#line default
#line hidden
#nullable disable
#nullable restore
#line 55 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\ContractResponse\Index.cshtml"
                                 if (Model == null)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <tr>\r\n                                        <td colspan=\"8\">No Record Found</td>\r\n                                    </tr>\r\n");
#nullable restore
#line 60 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\ContractResponse\Index.cshtml"
                                }
                                else
                                {
                                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 63 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\ContractResponse\Index.cshtml"
                                     foreach (var item in Model)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <tr>\r\n                                            <td>\r\n                                                <label> ");
#nullable restore
#line 67 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\ContractResponse\Index.cshtml"
                                                   Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </label>\r\n");
#nullable restore
#line 69 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\ContractResponse\Index.cshtml"
                                                   i++; 

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            </td>\r\n                                            <td>\r\n                                                ");
#nullable restore
#line 72 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\ContractResponse\Index.cshtml"
                                           Write(Html.ActionLink(item.CONTRACTNUMBER, "GetVendorContractModal", new { contractId = item.ID, contractStatus = item.CONTRACTSTATUS }, new { @class = "link blue", @id= "lnkcontract" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            </td>\r\n                                            <td>\r\n                                                ");
#nullable restore
#line 75 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\ContractResponse\Index.cshtml"
                                           Write(Html.DisplayFor(modelItem => item.DESCRIPTION));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                               \r\n                                            </td>\r\n                                            <td>\r\n                                                ");
#nullable restore
#line 79 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\ContractResponse\Index.cshtml"
                                           Write(Html.DisplayFor(modelItem => item.CONTRACTAMOUNT));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                               \r\n                                            </td>\r\n                                           \r\n                                            <td>\r\n                                                ");
#nullable restore
#line 84 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\ContractResponse\Index.cshtml"
                                           Write(Html.DisplayFor(modelItem => item.PAYMENTTENOR));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            </td>\r\n                                            <td>\r\n                                                ");
#nullable restore
#line 87 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\ContractResponse\Index.cshtml"
                                           Write(Html.DisplayFor(modelItem => item.PONUMBER));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            </td>\r\n                                            <td>\r\n                                                ");
#nullable restore
#line 90 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\ContractResponse\Index.cshtml"
                                           Write(Html.DisplayFor(modelItem => item.CORPORATENAME));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            </td>\r\n                                            <td>\r\n                                                ");
#nullable restore
#line 93 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\ContractResponse\Index.cshtml"
                                           Write(Html.DisplayFor(modelItem => item.CREATEDDATE));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            </td>\r\n\r\n                                            <td>\r\n");
#nullable restore
#line 97 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\ContractResponse\Index.cshtml"
                                                 if (item.CONTRACTSTATUS == "Awarded")
                                                {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                                    <div class=""status alert alert-success mb-0 py-1"" role=""alert"">
                                                        <label style=""width:80px"">Awarded</label>
                                                    </div>
");
#nullable restore
#line 102 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\ContractResponse\Index.cshtml"
                                                }
                                                else if (item.CONTRACTSTATUS == "Rejected")
                                                {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                                    <div class=""status alert alert-danger mb-0 py-1"" role=""alert"">
                                                        <label style=""width:80px"">Rejected</label>
                                                    </div>
");
#nullable restore
#line 108 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\ContractResponse\Index.cshtml"
                                                }
                                                else if (item.CONTRACTSTATUS == "Completed")
                                                {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                                    <div class=""status alert alert-info mb-0 py-1"" role=""alert"">
                                                        <label style=""width:80px"">Completed</label>
                                                    </div>
");
#nullable restore
#line 114 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\ContractResponse\Index.cshtml"
                                                }
                                                else if (item.CONTRACTSTATUS == "New")
                                                {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                                    <div class=""status alert alert-warning mb-0 py-1"" role=""alert"">
                                                        <label style=""width:80px""> New </label>
                                                    </div>
");
#nullable restore
#line 120 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\ContractResponse\Index.cshtml"
                                                }
                                                else if (item.CONTRACTSTATUS == "Pending")
                                                {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                                    <div class=""status alert alert-dark mb-0 py-1"" role=""alert"">
                                                        <label style=""width:80px"">Pending</label>
                                                    </div>
");
#nullable restore
#line 126 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\ContractResponse\Index.cshtml"
                                                }
                                                else if (item.CONTRACTSTATUS == "Declined")
                                                {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                                    <div class=""status alert alert-danger mb-0 py-1"" role=""alert"">
                                                        <label style=""width:80px"">Declined</label>
                                                    </div>
");
#nullable restore
#line 132 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\ContractResponse\Index.cshtml"
                                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            </td>\r\n                                        </tr>\r\n");
#nullable restore
#line 135 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\ContractResponse\Index.cshtml"
                                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 135 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\ContractResponse\Index.cshtml"
                                     
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </tbody>\r\n                        </table>\r\n\r\n                    </div>\r\n                   \r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n\r\n</div>\r\n\r\n<div id=\"cmodal\"></div>\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script>

        $(document).ready(function () {
            var vendorTable = $('#contractTable').DataTable({
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
        });
        $(""a.link"").on('click', function () {
            $.ajax({
                url: this.href,
                type: 'Get',
                cache: true,
                success: function (result) {
                   ");
                WriteLiteral(@" $('#cmodal').html(result).find('.modal').modal({
                        show: true
                    });
                }
            });
            return false;
        });
        $('#txtSearch').on('keyup', function () {
            var searchTxt = $(""#txtSearch"").val();
            $('#contractTable').DataTable().search(searchTxt).draw();
        });
        
    </script>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<VendorContractListModel>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591

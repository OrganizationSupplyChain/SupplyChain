#pragma checksum "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Vendor\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "92ba652a1cd714ba9a1f477c13237d6296845985"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Vendor_Index), @"mvc.1.0.view", @"/Views/Vendor/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"92ba652a1cd714ba9a1f477c13237d6296845985", @"/Views/Vendor/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5e7e6c2b2e2093347ee78387d906f49a77b633a7", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Vendor_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<VendorPendingApproveModel>
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
#line 4 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Vendor\Index.cshtml"
  
    ViewData["Title"] = "Vendor Management";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

<div class=""row mt-4"">
    <div class=""col-12 d-flex justify-content-between align-items-center"">
        <div class=""search-group"">
            <input type=""text"" style=""width: 300px;"" id=""txtSearch"" placeholder=""search"" class=""form-control pl-5""
                   aria-label=""Text input with checkbox"">
            <i class=""fa fa-search""></i>

            <input type=""text"" style=""width: 300px; display:none"" id=""txtSearchPending"" placeholder=""search"" class=""form-control pl-5""
                   aria-label=""Text input with checkbox"">
            <i class=""fa fa-search""></i>
        </div>
        <div>
            
            <div>
                <button type=""button"" class=""btn btn-outline-primary blue-outline-btn"" id=""lnkCreate"">
                    Create New ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "92ba652a1cd714ba9a1f477c13237d62968459855697", async() => {
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
            WriteLiteral("\r\n                </button>\r\n\r\n");
            WriteLiteral(@"            </div>           
        </div>
    </div>
</div>

<div class=""row my-5"">
    <div class=""col-12"">
        <ul class=""nav nav-tabs mb-4 border-bottom-0"" id=""myTab"" role=""tablist"">
            <li class=""nav-item"" role=""presentation"">
                <button class=""nav-link active tab-btn "" id=""all-vendors-tab"" data-toggle=""tab""
                        data-target=""#all-vendors"" type=""button"" role=""tab"" aria-controls=""all-vendors""
                        aria-selected=""true"">
                    All Vendors
                </button>
            </li>
            <li class=""nav-item"" role=""presentation"">
                <button class=""nav-link tab-btn"" id=""vendors-requests-tab"" data-toggle=""tab""
                        data-target=""#vendors-requests"" type=""button"" role=""tab""
                        aria-controls=""vendors-requests"" aria-selected=""false"">
                    New Vendors Request
                </button>
            </li>

        </ul>

        <div class=""ta");
            WriteLiteral(@"b-content"" id=""myTabContent"">
            <div class=""card my-card tab-pane active"" id=""all-vendors"">
                <div class=""card-body px-0"">
                    <div class=""header px-4 pb-3 d-flex justify-content-between align-items-center"">
                        <h5 class=""card-title mb-0"">Vendors List</h5>

                    </div>

                    <div class=""notif-wrapper p-4 notif-card "" style=""height: 55vh;"">
                        <table id=""vendorTable"" class=""table example "" style=""width:100%"">
                            <thead>
                                <tr>
                                    <th></th>
                                    <th>Vendor Name</th>
                                    <th>Vendor Category</th>
                                    <th>Vendor Email</th>
                                    <th>Vendor Account No.</th>
                                    <th>Vendor Address</th>
                                    <th>Vendor Bank</th>
     ");
            WriteLiteral(@"                               <th>Vendor TIN/RC</th>
                                    <th>Date Initiated</th>
                                    <th>Status</th>
                                    <th></th>
                                </tr>
                            </thead>
                            <tbody>
");
#nullable restore
#line 81 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Vendor\Index.cshtml"
                                   int i = 1; 

#line default
#line hidden
#nullable disable
#nullable restore
#line 82 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Vendor\Index.cshtml"
                                 if (Model.vendorapproved == null || Model.vendorapproved.Count() == 0)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <tr>\r\n                                        <td colspan=\"9\">No Record Found</td>\r\n                                    </tr>\r\n");
#nullable restore
#line 87 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Vendor\Index.cshtml"
                                }
                                else
                                {
                                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 90 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Vendor\Index.cshtml"
                                     foreach (var item in Model.vendorapproved)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <tr>\r\n                                            <td>\r\n                                                <label> ");
#nullable restore
#line 94 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Vendor\Index.cshtml"
                                                   Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </label>\r\n");
#nullable restore
#line 95 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Vendor\Index.cshtml"
                                                   i++; 

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            </td>\r\n                                            <td>\r\n                                                ");
#nullable restore
#line 98 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Vendor\Index.cshtml"
                                           Write(Html.ActionLink(item.NAME, "ViewVendorDetailsModal", new { vendorId = item.ID }, new { @class = "link blue", @id = "lnkcontract" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            </td>\r\n                                            <td>\r\n                                                ");
#nullable restore
#line 101 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Vendor\Index.cshtml"
                                           Write(Html.DisplayFor(modelItem => item.CATEGORY));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            </td>\r\n\r\n\r\n                                            <td>\r\n                                                ");
#nullable restore
#line 106 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Vendor\Index.cshtml"
                                           Write(Html.DisplayFor(modelItem => item.EMAIL));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            </td>\r\n                                            <td>\r\n                                                ");
#nullable restore
#line 109 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Vendor\Index.cshtml"
                                           Write(Html.DisplayFor(modelItem => item.ACCOUNTNO));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            </td>\r\n                                            <td>\r\n                                                ");
#nullable restore
#line 112 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Vendor\Index.cshtml"
                                           Write(Html.DisplayFor(modelItem => item.ADDRESS));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            </td>\r\n                                            <td>\r\n                                                ");
#nullable restore
#line 115 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Vendor\Index.cshtml"
                                           Write(Html.DisplayFor(modelItem => item.BANK));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            </td>\r\n                                            <td>\r\n                                                ");
#nullable restore
#line 118 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Vendor\Index.cshtml"
                                           Write(Html.DisplayFor(modelItem => item.TIN_RC));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            </td>\r\n                                            <td>\r\n                                                ");
#nullable restore
#line 121 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Vendor\Index.cshtml"
                                           Write(Html.DisplayFor(modelItem => item.DATECREATED));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            </td>\r\n                                            <td>\r\n                                                <label class=\"switch\">\r\n                                                    <input type=\"checkbox\"");
            BeginWriteAttribute("value", " value=\"", 6329, "\"", 6353, 1);
#nullable restore
#line 125 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Vendor\Index.cshtml"
WriteAttributeValue("", 6337, item.STATUSBOOL, 6337, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("checked", " checked=\"", 6354, "\"", 6380, 1);
#nullable restore
#line 125 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Vendor\Index.cshtml"
WriteAttributeValue("", 6364, item.STATUSBOOL, 6364, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" name=\"STATUSBOOL\"");
            BeginWriteAttribute("onclick", "  onclick=\"", 6399, "\"", 6453, 5);
            WriteAttributeValue("", 6410, "VendorStatusChange(\'\'", 6410, 21, true);
            WriteAttributeValue(" ", 6431, "+", 6432, 2, true);
#nullable restore
#line 125 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Vendor\Index.cshtml"
WriteAttributeValue(" ", 6433, item.ID, 6434, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue(" ", 6442, "+", 6443, 2, true);
            WriteAttributeValue(" ", 6444, "\'\',this)", 6445, 9, true);
            EndWriteAttribute();
            WriteLiteral(@"/>
                                                    <span class=""slider round""></span>                                                   
                                                </label>
                                            </td>
                                            <td>
                                                <a");
            BeginWriteAttribute("href", " href=\"", 6806, "\"", 6872, 1);
#nullable restore
#line 130 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Vendor\Index.cshtml"
WriteAttributeValue("", 6813, Url.Action("ModifyVendor", "Vendor", new { id = item.ID }), 6813, 59, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"edit\">\r\n                                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "92ba652a1cd714ba9a1f477c13237d629684598518193", async() => {
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
            WriteLiteral("\r\n                                                </a>\r\n                                            </td>\r\n                                        </tr>\r\n");
#nullable restore
#line 135 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Vendor\Index.cshtml"
                                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 135 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Vendor\Index.cshtml"
                                     

                                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                            </tbody>
                        </table>

                    </div>
                </div>
            </div>


            <div class=""card my-card tab-pane"" id=""vendors-requests"">
                <div class=""card-body px-0"">
                    <div class=""header px-4 pb-3 d-flex justify-content-between align-items-center"">
                        <h5 class=""card-title mb-0"">Vendors Requested</h5>

                    </div>

                    <div class=""notif-wrapper p-4 notif-card "" style=""height: 55vh;"">

                        <table id=""vendorTablePending"" class=""table  example"" style=""width:100%"">
                            <thead>
                                <tr>
                                    <th></th>
                                    <th>Name</th>
                                    <th>Category</th>
                                    <th>Email</th>
                                    <th>Account No.</th>
                     ");
            WriteLiteral(@"               <th>Address</th>
                                    <th>Bank</th>
                                    <th>TIN/RC</th>
                                    <th>ServiceNature</th>
                                    <th>Date Initiated</th>
                                </tr>
                            </thead>
                            <tbody>
");
#nullable restore
#line 171 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Vendor\Index.cshtml"
                               int j = 1; 

#line default
#line hidden
#nullable disable
#nullable restore
#line 172 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Vendor\Index.cshtml"
                             if (Model.vendorpending == null || Model.vendorpending.Count() == 0)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <tr>\r\n                                    <td colspan=\"11\">No Record Found</td>\r\n                                </tr>\r\n");
#nullable restore
#line 177 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Vendor\Index.cshtml"
                            }
                            else
                            {
                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 180 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Vendor\Index.cshtml"
                                 foreach (var item in Model.vendorpending)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <tr>\r\n                                        <td>\r\n                                            <label> ");
#nullable restore
#line 184 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Vendor\Index.cshtml"
                                               Write(j);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </label>\r\n");
#nullable restore
#line 185 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Vendor\Index.cshtml"
                                               j++; 

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        </td>\r\n                                        <td>\r\n                                            ");
#nullable restore
#line 188 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Vendor\Index.cshtml"
                                       Write(Html.ActionLink(item.NAME, "ViewVendorDetailsApprovalModal", new { vendorId = item.ID }, new { @class = "link blue", @id = "lnkcontract" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </td>\r\n                                        <td>\r\n                                            ");
#nullable restore
#line 191 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Vendor\Index.cshtml"
                                       Write(Html.DisplayFor(modelItem => item.CATEGORY));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </td>\r\n\r\n                                        <td>\r\n                                            ");
#nullable restore
#line 195 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Vendor\Index.cshtml"
                                       Write(Html.DisplayFor(modelItem => item.EMAIL));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </td>\r\n                                        <td>\r\n                                            ");
#nullable restore
#line 198 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Vendor\Index.cshtml"
                                       Write(Html.DisplayFor(modelItem => item.ACCOUNTNO));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </td>\r\n                                        <td>\r\n                                            ");
#nullable restore
#line 201 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Vendor\Index.cshtml"
                                       Write(Html.DisplayFor(modelItem => item.ADDRESS));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </td>\r\n                                        <td>\r\n                                            ");
#nullable restore
#line 204 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Vendor\Index.cshtml"
                                       Write(Html.DisplayFor(modelItem => item.BANK));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </td>\r\n                                        <td>\r\n                                            ");
#nullable restore
#line 207 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Vendor\Index.cshtml"
                                       Write(Html.DisplayFor(modelItem => item.TIN_RC));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </td>\r\n                                        <td>\r\n                                            ");
#nullable restore
#line 210 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Vendor\Index.cshtml"
                                       Write(Html.DisplayFor(modelItem => item.SERVICENATURE));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </td>\r\n                                        <td>\r\n                                            ");
#nullable restore
#line 213 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Vendor\Index.cshtml"
                                       Write(Html.DisplayFor(modelItem => item.DATECREATED));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </td>\r\n                                                                               \r\n                                    </tr>\r\n");
#nullable restore
#line 217 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Vendor\Index.cshtml"
                                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 217 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Vendor\Index.cshtml"
                                 

                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </tbody>\r\n                        </table>\r\n\r\n                    </div>\r\n                  \r\n\r\n\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n<div id=\"cmodal\"></div>\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script>
        $(document).ready(function () {
            
            $('#vendorTable').DataTable({
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

            $('#vendorTablePending').DataTable({
                dom: 'lrtip',
                order: [],
                paging: true,
                info: true
            });

        });

        $(""a.link"").on('click', function () ");
                WriteLiteral(@"{
            $.ajax({
                url: this.href,
                type: 'Get',
                cache: true,
                success: function (result) {
                    $('#cmodal').html(result).find('.modal').modal({
                        show: true
                    });
                }
            });
            return false;
        });

        $(""#lnkCreate"").on('click', function () {

            window.location.href = '");
#nullable restore
#line 291 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Vendor\Index.cshtml"
                               Write(Url.Action("_AddVendor", "Vendor"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"';
        });

        $('#txtSearch').on('keyup', function () {

            var searchTxt = $(""#txtSearch"").val();
            $('#vendorTable').DataTable().search(searchTxt).draw();
        });

        $('#txtSearchPending').on('keyup', function () {

            var searchTxt = $(""#txtSearchPending"").val();
            $('#vendorTablePending').DataTable().search(searchTxt).draw();
        });

        $('button[data-toggle=""tab""]').on('shown.bs.tab', function (e) {
            console.log(""here"");
            var target = $(e.target).attr(""data-target"") // activated tab
            if (target == ""#all-vendors"") {

                $(""#txtSearch"").show();
                $(""#txtSearchPending"").hide();
            } else {

                 $(""#txtSearch"").hide();
                $(""#txtSearchPending"").show();
            }
        });

        function VendorStatusChange(id, e) {
           
            $.ajax({
                // async: true,
                data: { id: i");
                WriteLiteral(@"d, status: e.checked },
                url: '/Vendor/VendorStatusChange',
                type: 'POST',
                success: function (result) {
                    if (result == true) {
                        swal(""Success"", ""Vendor status successfully updated"", ""success"");
                    } else {
                        swal(""Error"", ""unable to update vendor status"", ""error"");
                    }
                }
            });
            return true;
        }
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<VendorPendingApproveModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
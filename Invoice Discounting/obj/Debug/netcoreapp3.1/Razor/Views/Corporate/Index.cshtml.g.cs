#pragma checksum "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Corporate\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b1fa3597fd5f06b9b1b5109ac761398356bea9b9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Corporate_Index), @"mvc.1.0.view", @"/Views/Corporate/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b1fa3597fd5f06b9b1b5109ac761398356bea9b9", @"/Views/Corporate/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5e7e6c2b2e2093347ee78387d906f49a77b633a7", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Corporate_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CorporatePendingApproveModel>
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
#line 2 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Corporate\Index.cshtml"
  
    ViewData["Title"] = "Corporate Management";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

<div class=""row mt-4"">
    <div class=""col-12 d-flex justify-content-between align-items-center"">
        <div class=""search-group"" id=""dvcorporatesearch"">
            <input type=""text"" style=""width: 300px;"" placeholder=""search"" id=""txtcorporatesearch"" class=""form-control pl-5""
                   aria-label=""Text input with checkbox"">
            <i class=""fa fa-search""></i>
        </div>
        <div class=""search-group"" id=""dvrequestsearch"" style=""display:none"">
            <input type=""text"" style=""width: 300px;"" placeholder=""search"" id=""txtrequestsearch"" class=""form-control pl-5""
                   aria-label=""Text input with checkbox"">
            <i class=""fa fa-search""></i>
        </div>
        <div>
            <div>
                <button type=""button"" class=""btn btn-outline-primary blue-outline-btn"" id=""lnkCreate"">
                    Create New ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "b1fa3597fd5f06b9b1b5109ac761398356bea9b95826", async() => {
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
                <button class=""nav-link active tab-btn "" id=""all-corporate-tab"" data-toggle=""tab""
                        data-target=""#all-corporate"" type=""button"" role=""tab"" aria-controls=""all-corporate""
                        aria-selected=""true"">
                    All Corporates
                </button>
            </li>
            <li class=""nav-item"" role=""presentation"">
                <button class=""nav-link tab-btn"" id=""corporate-requests-tab"" data-toggle=""tab""
                        data-target=""#corporate-requests"" type=""button"" role=""tab""
                        aria-controls=""corporate-requests"" aria-selected=""false"">
                    New Corporate Request
                </button>
            </li>

        </ul>

        <div cla");
            WriteLiteral(@"ss=""tab-content"" id=""myTabContent"">
            <div class=""card my-card tab-pane active"" id=""all-corporate"">
                <div class=""card-body px-0"">
                    <div class=""header px-4 pb-3 d-flex justify-content-between align-items-center"">
                        <h5 class=""card-title mb-0"">Corporate List</h5>

                    </div>

                    <div class=""notif-wrapper p-4 notif-card "" style=""height: 55vh;"">
                        <table id=""corporatelist"" class=""table example "" style=""width:100%"">
                            <thead>
                                <tr>
                                    <th></th>
                                    <th>Corporate Name</th>
                                    <th>Email</th>
                                    <th>Phone No.</th>
                                    <th>Account No.</th>
                                    <th>Interest Rate</th>
                                    <th>Available Line</th>
        ");
            WriteLiteral(@"                            <th>Date Initiated</th>
                                    <th></th>
                                    <th></th>
                                </tr>
                            </thead>
                            <tbody>
");
#nullable restore
#line 78 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Corporate\Index.cshtml"
                                   int i = 1; 

#line default
#line hidden
#nullable disable
#nullable restore
#line 79 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Corporate\Index.cshtml"
                                 if (Model.corporateapproved == null)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <tr>\r\n                                        <td colspan=\"9\">No Record Found</td>\r\n                                    </tr>\r\n");
#nullable restore
#line 84 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Corporate\Index.cshtml"
                                }
                                else
                                {
                                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 87 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Corporate\Index.cshtml"
                                     foreach (var item in Model.corporateapproved)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <tr>\r\n                                            <td>\r\n                                                <label> ");
#nullable restore
#line 91 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Corporate\Index.cshtml"
                                                   Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </label>\r\n");
#nullable restore
#line 92 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Corporate\Index.cshtml"
                                                   i++; 

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            </td>\r\n\r\n                                            <td>\r\n\r\n                                                ");
#nullable restore
#line 97 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Corporate\Index.cshtml"
                                           Write(Html.ActionLink(item.CORPORATENAME, "ViewCorporateDetailsModal", new { corporateId = item.ID }, new { @class = "link blue" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            </td>\r\n                                            <td>\r\n                                                ");
#nullable restore
#line 100 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Corporate\Index.cshtml"
                                           Write(Html.DisplayFor(modelItem => item.PRINCIPALEMAIL));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            </td>\r\n                                            <td>\r\n                                                ");
#nullable restore
#line 103 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Corporate\Index.cshtml"
                                           Write(Html.DisplayFor(modelItem => item.PRINCIPALPHONENO));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            </td>\r\n                                            <td>\r\n                                                ");
#nullable restore
#line 106 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Corporate\Index.cshtml"
                                           Write(Html.DisplayFor(modelItem => item.PRINCIPALACCOUNTNO));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            </td>\r\n                                            <td>\r\n                                                ");
#nullable restore
#line 109 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Corporate\Index.cshtml"
                                           Write(Html.DisplayFor(modelItem => item.INTERESTRATE));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            </td>\r\n                                            <td>\r\n                                                ");
#nullable restore
#line 112 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Corporate\Index.cshtml"
                                           Write(Html.DisplayFor(modelCItem => item.AVAILABLELINEOFCREDIT));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            </td>\r\n                                            <td>\r\n                                                ");
#nullable restore
#line 115 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Corporate\Index.cshtml"
                                           Write(Html.DisplayFor(modelItem => item.CREATEDDATE));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            </td>\r\n                                            <td>\r\n                                                <label class=\"switch\">\r\n                                                    <input type=\"checkbox\"");
            BeginWriteAttribute("value", " value=\"", 6092, "\"", 6116, 1);
#nullable restore
#line 119 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Corporate\Index.cshtml"
WriteAttributeValue("", 6100, item.STATUSBOOL, 6100, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("checked", " checked=\"", 6117, "\"", 6143, 1);
#nullable restore
#line 119 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Corporate\Index.cshtml"
WriteAttributeValue("", 6127, item.STATUSBOOL, 6127, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" name=\"STATUSBOOL\"");
            BeginWriteAttribute("onclick", " onclick=\"", 6162, "\"", 6218, 5);
            WriteAttributeValue("", 6172, "CorporateStatusChange(\'\'", 6172, 24, true);
            WriteAttributeValue(" ", 6196, "+", 6197, 2, true);
#nullable restore
#line 119 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Corporate\Index.cshtml"
WriteAttributeValue(" ", 6198, item.ID, 6199, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue(" ", 6207, "+", 6208, 2, true);
            WriteAttributeValue(" ", 6209, "\'\',this)", 6210, 9, true);
            EndWriteAttribute();
            WriteLiteral(@" />
                                                    <span class=""slider round""></span>
                                                </label>
                                            </td>
                                            <td>
                                                <a");
            BeginWriteAttribute("href", " href=\"", 6521, "\"", 6593, 1);
#nullable restore
#line 124 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Corporate\Index.cshtml"
WriteAttributeValue("", 6528, Url.Action("ModifyCorporate", "Corporate", new { id = item.ID }), 6528, 65, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"link blue\">\r\n                                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "b1fa3597fd5f06b9b1b5109ac761398356bea9b917794", async() => {
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
#line 129 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Corporate\Index.cshtml"
                                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 129 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Corporate\Index.cshtml"
                                     

                                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                            </tbody>
                        </table>

                    </div>
                  
                </div>
            </div>


            <div class=""card my-card tab-pane"" id=""corporate-requests"">
                <div class=""card-body px-0"">
                    <div class=""header px-4 pb-3 d-flex justify-content-between align-items-center"">
                        <h5 class=""card-title mb-0"">Corporate Requested</h5>

                    </div>

                    <div class=""notif-wrapper p-4 notif-card "" style=""height: 55vh;"">

                        <table id=""corporaterequest"" class=""table  example"" style=""width:100%"">
                            <thead>
                                <tr>
                                    <th></th>
                                    <th>Corporate Name</th>
                                    <th>Email</th>
                                    <th>Phone No.</th>
                                    <th>Accoun");
            WriteLiteral(@"t No.</th>
                                    <th>Interest Rate</th>
                                    <th>Available Line</th>
                                    <th>Date Initiated</th>
                                </tr>
                            </thead>
                            <tbody>
");
#nullable restore
#line 164 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Corporate\Index.cshtml"
                                   int j = 1; 

#line default
#line hidden
#nullable disable
#nullable restore
#line 165 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Corporate\Index.cshtml"
                                 if (Model.corporatepending == null)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <tr>\r\n                                        <td colspan=\"9\">No Record Found</td>\r\n                                    </tr>\r\n");
#nullable restore
#line 170 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Corporate\Index.cshtml"
                                }
                                else
                                {
                                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 173 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Corporate\Index.cshtml"
                                     foreach (var item in Model.corporatepending)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <tr>\r\n                                            <td>\r\n                                                <label> ");
#nullable restore
#line 177 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Corporate\Index.cshtml"
                                                   Write(j);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </label>\r\n");
#nullable restore
#line 178 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Corporate\Index.cshtml"
                                                   j++; 

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            </td>\r\n                                            <td>\r\n                                                ");
#nullable restore
#line 181 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Corporate\Index.cshtml"
                                           Write(Html.ActionLink(item.CORPORATENAME, "ViewCorporateDetailsApprovalModal", new { corporateId = item.ID }, new { @class = "link blue", @id = "lnkcontract" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            </td>\r\n                                            <td>\r\n                                                ");
#nullable restore
#line 184 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Corporate\Index.cshtml"
                                           Write(Html.DisplayFor(modelItem => item.PRINCIPALEMAIL));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            </td>\r\n\r\n\r\n                                            <td>\r\n                                                ");
#nullable restore
#line 189 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Corporate\Index.cshtml"
                                           Write(Html.DisplayFor(modelItem => item.PRINCIPALPHONENO));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            </td>\r\n                                            <td>\r\n                                                ");
#nullable restore
#line 192 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Corporate\Index.cshtml"
                                           Write(Html.DisplayFor(modelItem => item.PRINCIPALACCOUNTNO));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            </td>\r\n                                            <td>\r\n                                                ");
#nullable restore
#line 195 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Corporate\Index.cshtml"
                                           Write(Html.DisplayFor(modelItem => item.INTERESTRATE));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            </td>\r\n                                            <td>\r\n                                                ");
#nullable restore
#line 198 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Corporate\Index.cshtml"
                                           Write(Html.DisplayFor(modelItem => item.AVAILABLELINEOFCREDIT));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            </td>\r\n                                            <td>\r\n                                                ");
#nullable restore
#line 201 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Corporate\Index.cshtml"
                                           Write(Html.DisplayFor(modelItem => item.CREATEDDATE));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            </td>\r\n\r\n                                        </tr>\r\n");
#nullable restore
#line 205 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Corporate\Index.cshtml"
                                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 205 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Corporate\Index.cshtml"
                                     

                                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                            </tbody>
                        </table>

                    </div>



                </div>
            </div>
        </div>
    </div>
</div>







<div id=""cmodal""></div>
<div id=""lnkcontract""></div>
");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script>
      
        $(document).ready(function () {

            //if($('#DelegateChkBox').val()== true)
            //{
            //    $('#IsEnabled').prop(""disabled"", false);
            //    console.log('not Checked');
            //}
            //else
            //{
            //    $('#IsEnabled').prop(""disabled"", true);
            //    console.log('Checked');
            //}

            $('#corporatelist').DataTable({
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
                WriteLiteral(@"
                        titleAttr: 'PDF'
                    }
                ]
            });
            $('#corporaterequest').DataTable({
                dom: 'lrtip',
                order: [],
                paging: true,
                info: true
            });
        });

        $(""#lnkcontract"").on('click', function () {
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
#line 291 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Corporate\Index.cshtml"
                               Write(Url.Action("_AddCorporates", "Corporate"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"';
        });

        $('#txtcorporatesearch').on('keyup', function () {

            var searchTxt = $(""#txtcorporatesearch"").val();
            $('#corporatelist').DataTable().search(searchTxt).draw();
        });

        $('#txtrequestsearch').on('keyup', function () {

            var searchTxt = $(""#txtrequestsearch"").val();
            $('#corporaterequest').DataTable().search(searchTxt).draw();
        });

        $('button[data-toggle=""tab""]').on('shown.bs.tab', function (e) {

            var target = $(e.target).attr(""data-target""); // activated tab
            if (target == ""#all-corporate"") {
                $(""#dvrequestsearch"").hide();
                $(""#dvcorporatesearch"").show();

           } else {
                $(""#dvrequestsearch"").show();
                $(""#dvcorporatesearch"").hide();
            }
        });

        function CorporateStatusChange(id, e) {
            $.ajax({
                data: { id: id, status: e.checked },
                url");
                WriteLiteral(@": '/Corporate/CorporateStatusChange',
                type: 'POST',
                success: function (result) {
                    if (result == true) {
                        swal(""Success"", ""Corporate status successfully updated"", ""success"");
                    } else {
                        swal(""Error"", ""unable to update corporate status"", ""error"");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CorporatePendingApproveModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
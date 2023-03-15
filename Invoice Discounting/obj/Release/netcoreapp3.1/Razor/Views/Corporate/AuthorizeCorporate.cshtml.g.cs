#pragma checksum "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Corporate\AuthorizeCorporate.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5336037cbcdda73a51a7be4301197b5b46daa129"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Corporate_AuthorizeCorporate), @"mvc.1.0.view", @"/Views/Corporate/AuthorizeCorporate.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5336037cbcdda73a51a7be4301197b5b46daa129", @"/Views/Corporate/AuthorizeCorporate.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5e7e6c2b2e2093347ee78387d906f49a77b633a7", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Corporate_AuthorizeCorporate : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<CorporateDetailsPending>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Corporate\AuthorizeCorporate.cshtml"
  
	ViewData["Title"] = "AuthorizeCorporate";

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"container-fluid\">\r\n\r\n\t<!-- Page Heading -->\r\n\t<h1 class=\"h3 mb-2 text-gray-800\">Authorize Corporate Details</h1>\r\n\r\n\t<p><label style=\"color:red\">");
#nullable restore
#line 10 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Corporate\AuthorizeCorporate.cshtml"
                           Write(Html.TempData["authMessage"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</label></p>

	<div class=""card shadow mb-4"">
		<div class=""card-header py-3"">
			<h6 class=""m-0 font-weight-bold text-primary"">Pending Corporate</h6>
		</div>
		<div class=""card-body"">
			<div class=""table-responsive"">

				<table class=""table table-bordered"" id=""dataTable"" width=""100%"" style=""font-family:Calibri;font-size:14px"" cellspacing=""0"">
					<thead>
                        <tr style=""background-color:lightgrey; color:black"">
                            <th>Corporate Name</th>
                            <th>Email</th>
                            <th>Phone No.</th>
                            <th>Account No.</th>
                            <th>Interest Rate</th>
                            <th>Available Line</th>
                            <th>Date Initiated</th>
                            <th></th>
                        </tr>
					</thead>
					<tbody>
");
#nullable restore
#line 33 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Corporate\AuthorizeCorporate.cshtml"
                         foreach (var item in Model)
						{

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\r\n                            <td>\r\n                                ");
#nullable restore
#line 37 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Corporate\AuthorizeCorporate.cshtml"
                           Write(Html.DisplayFor(modelItem => item.CORPORATENAME));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
#nullable restore
#line 40 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Corporate\AuthorizeCorporate.cshtml"
                           Write(Html.DisplayFor(modelItem => item.PRINCIPALEMAIL));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
#nullable restore
#line 43 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Corporate\AuthorizeCorporate.cshtml"
                           Write(Html.DisplayFor(modelItem => item.PRINCIPALPHONENO));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
#nullable restore
#line 46 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Corporate\AuthorizeCorporate.cshtml"
                           Write(Html.DisplayFor(modelItem => item.PRINCIPALACCOUNTNO));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
#nullable restore
#line 49 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Corporate\AuthorizeCorporate.cshtml"
                           Write(Html.DisplayFor(modelItem => item.INTERESTRATE));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
#nullable restore
#line 52 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Corporate\AuthorizeCorporate.cshtml"
                           Write(Html.DisplayFor(modelItem => item.AVAILABLELINEOFCREDIT));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
#nullable restore
#line 55 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Corporate\AuthorizeCorporate.cshtml"
                           Write(Html.DisplayFor(modelItem => item.CREATEDDATE));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                            <td style=\"width:120px\">\r\n                                ");
#nullable restore
#line 58 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Corporate\AuthorizeCorporate.cshtml"
                           Write(Html.ActionLink("Authorize", "Auth", new { id = item.ID }, new { @class = "auth" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                            </td>\r\n                        </tr>\r\n");
#nullable restore
#line 62 "C:\Users\Olamide\Documents\AccessBank\Repos\accessbank_invoice_discounting\Invoice Discounting\Views\Corporate\AuthorizeCorporate.cshtml"
						}

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t</tbody>\r\n\t\t\t\t</table>\r\n\t\t\t</div>\r\n\t\t</div>\r\n\t</div>\r\n</div>\r\n<div id=\"myModal\"></div>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
	<script>
			$(""a.auth"").on('click', function () {
				$.ajax({
					url: this.href,
					type: 'Get',
					cache: false,
					success: function (result) {
						$('#myModal').html(result).find('.modal').modal({
							show: true
						});
					}
				});
				return false;
			});
	</script>
");
            }
            );
            WriteLiteral("\r\n\r\n\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<CorporateDetailsPending>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591

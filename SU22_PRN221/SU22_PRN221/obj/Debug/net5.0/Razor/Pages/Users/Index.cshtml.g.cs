#pragma checksum "G:\PRN221\SU22_PRN221\SU22_PRN221\Pages\Users\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c75b38f8361dab7149569bcfe28560edb26b85c3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(SU22_PRN221.Pages.Users.Pages_Users_Index), @"mvc.1.0.razor-page", @"/Pages/Users/Index.cshtml")]
namespace SU22_PRN221.Pages.Users
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
#line 1 "G:\PRN221\SU22_PRN221\SU22_PRN221\Pages\_ViewImports.cshtml"
using SU22_PRN221;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c75b38f8361dab7149569bcfe28560edb26b85c3", @"/Pages/Users/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a3234e772ca6085a0b01df9cee761402f6d78a5b", @"/Pages/_ViewImports.cshtml")]
    #nullable restore
    public class Pages_Users_Index : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "./Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "G:\PRN221\SU22_PRN221\SU22_PRN221\Pages\Users\Index.cshtml"
  
     Layout = "~/Pages/Shared/_LayoutStaff.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<!-- ============================================================== -->
<!-- wrapper  -->
<!-- ============================================================== -->
<div class=""dashboard-wrapper"">
    <div class=""dashboard-ecommerce"">
        <div class=""container-fluid dashboard-content "">
            <!-- ============================================================== -->
            <!-- pageheader  -->
            <!-- ============================================================== -->
            <div class=""row"">
                <div class=""col-xl-12 col-lg-12 col-md-12 col-sm-12 col-12"">
                    <div class=""page-header"">
                        <h2 class=""pageheader-title"">Product Manage </h2>
                        <div class=""page-breadcrumb"">
                            <nav aria-label=""breadcrumb"">
                                <ol class=""breadcrumb"">
                                    <li class=""breadcrumb-item""><a href=""#"" class=""breadcrumb-link"">Dashboard</a></li>
   ");
            WriteLiteral(@"                                 <li class=""breadcrumb-item active"" aria-current=""page"">Users</li>
                                </ol>
                            </nav>
                        </div>
                    </div>
                </div>
            </div>
            <!-- ============================================================== -->
            <!-- end pageheader  -->
            <!-- ============================================================== -->
            <div class=""ecommerce-widget"">


                <div class=""row"">
                    <!-- ============================================================== -->
                    <!-- ============================================================== -->
                    <!-- recent orders  -->
                    <!-- ============================================================== -->
                    <div class=""col-12"">
                        <div class=""card"">
                            <h5 class=""card-");
            WriteLiteral(@"header"">Product</h5>
                            <div class=""card-body p-0"">
                                <div class=""table-responsive"">
                                    <table class=""table"">
                                        <thead class=""bg-light"">
                                            <tr class=""border-0"">
                                                <th class=""border-0"">#</th>
                                                <th>Id</th>
                                                <th>Username</th>
                                                <th>Password</th>
                                                <th>Email</th>
                                                <th>Phone Number</th>
                                                <th>First Name</th>
                                                <th>Last Name</th>
                                                <th>Address</th>
                                                <th>Created Date</th>
        ");
            WriteLiteral("                                        <th>Action</th>\r\n                                            </tr>\r\n                                        </thead>\r\n                                        <tbody>\r\n");
#nullable restore
#line 63 "G:\PRN221\SU22_PRN221\SU22_PRN221\Pages\Users\Index.cshtml"
                                             foreach (var item in Model.Users)
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                <tr>\r\n                                                    <td>");
#nullable restore
#line 66 "G:\PRN221\SU22_PRN221\SU22_PRN221\Pages\Users\Index.cshtml"
                                                   Write(item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                    <td>");
#nullable restore
#line 67 "G:\PRN221\SU22_PRN221\SU22_PRN221\Pages\Users\Index.cshtml"
                                                   Write(item.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                    <td>********</td>\r\n                                                    <td>");
#nullable restore
#line 69 "G:\PRN221\SU22_PRN221\SU22_PRN221\Pages\Users\Index.cshtml"
                                                   Write(item.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                    <td>");
#nullable restore
#line 70 "G:\PRN221\SU22_PRN221\SU22_PRN221\Pages\Users\Index.cshtml"
                                                   Write(item.PhoneNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                    <td>");
#nullable restore
#line 71 "G:\PRN221\SU22_PRN221\SU22_PRN221\Pages\Users\Index.cshtml"
                                                   Write(item.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                    <td>");
#nullable restore
#line 72 "G:\PRN221\SU22_PRN221\SU22_PRN221\Pages\Users\Index.cshtml"
                                                   Write(item.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                    <td>");
#nullable restore
#line 73 "G:\PRN221\SU22_PRN221\SU22_PRN221\Pages\Users\Index.cshtml"
                                                   Write(item.Address);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                    <td>");
#nullable restore
#line 74 "G:\PRN221\SU22_PRN221\SU22_PRN221\Pages\Users\Index.cshtml"
                                                   Write(item.CreatedDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                    <td>\r\n                                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c75b38f8361dab7149569bcfe28560edb26b85c39858", async() => {
                WriteLiteral("Delete");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 76 "G:\PRN221\SU22_PRN221\SU22_PRN221\Pages\Users\Index.cshtml"
                                                                                 WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                                    </td>\r\n                                                </tr>\r\n");
#nullable restore
#line 79 "G:\PRN221\SU22_PRN221\SU22_PRN221\Pages\Users\Index.cshtml"
                                            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- ============================================================== -->
                    <!-- end recent orders  -->

                </div>

            </div>
        </div>
    </div>

</div>
<!-- ============================================================== -->
<!-- end wrapper  -->
<!-- ============================================================== -->




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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SU22_PRN221.Pages.Users.IndexModel> Html { get; private set; } = default!;
        #nullable disable
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<SU22_PRN221.Pages.Users.IndexModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<SU22_PRN221.Pages.Users.IndexModel>)PageContext?.ViewData;
        public SU22_PRN221.Pages.Users.IndexModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
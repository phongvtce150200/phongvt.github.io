#pragma checksum "C:\Users\vthan\Downloads\SU22_PRN2212\SU22_PRN2212\SU22_PRN221\Pages\Messages\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "47e39a65a5ea0a8fabd2b1f6eee0125e0e0ff63c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(SU22_PRN221.Pages.Messages.Pages_Messages_Index), @"mvc.1.0.razor-page", @"/Pages/Messages/Index.cshtml")]
namespace SU22_PRN221.Pages.Messages
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
#line 1 "C:\Users\vthan\Downloads\SU22_PRN2212\SU22_PRN2212\SU22_PRN221\Pages\_ViewImports.cshtml"
using SU22_PRN221;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"47e39a65a5ea0a8fabd2b1f6eee0125e0e0ff63c", @"/Pages/Messages/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a3234e772ca6085a0b01df9cee761402f6d78a5b", @"/Pages/_ViewImports.cshtml")]
    #nullable restore
    public class Pages_Messages_Index : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("input_msg_write"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("chat-form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/microsoft/signalr/dist/browser/signalr.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "C:\Users\vthan\Downloads\SU22_PRN2212\SU22_PRN2212\SU22_PRN221\Pages\Messages\Index.cshtml"
  
    Layout = "~/Pages/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<link rel=""stylesheet"" href=""https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css"">

<div class=""messaging"">
    <div class=""inbox_msg"">
        <div class=""inbox_people"" style=""width: 100%"">
            <div class=""headind_srch"">
                <div class=""recent_heading"">
                </div>
            </div>
            <div class=""mesgs"" style=""width: 100%"">
                <div class=""msg_history"" id=""msg_history"">
");
#nullable restore
#line 18 "C:\Users\vthan\Downloads\SU22_PRN2212\SU22_PRN2212\SU22_PRN221\Pages\Messages\Index.cshtml"
                     foreach (var message in Model.chatMessages)
                    {
                        if (message.Type == Models.ChatMessage.Types.Receiver)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <div class=\"incoming_msg\">\r\n");
            WriteLiteral("                                <div class=\"received_msg\">\r\n                                    <div class=\"received_withd_msg\">\r\n                                        <p>");
#nullable restore
#line 26 "C:\Users\vthan\Downloads\SU22_PRN2212\SU22_PRN2212\SU22_PRN221\Pages\Messages\Index.cshtml"
                                      Write(message.Content);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                                        <span class=\"time_date\">");
#nullable restore
#line 27 "C:\Users\vthan\Downloads\SU22_PRN2212\SU22_PRN2212\SU22_PRN221\Pages\Messages\Index.cshtml"
                                                           Write(message.Created.ToLocalTime());

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                                    </div>\r\n                                </div>\r\n                            </div>\r\n");
#nullable restore
#line 31 "C:\Users\vthan\Downloads\SU22_PRN2212\SU22_PRN2212\SU22_PRN221\Pages\Messages\Index.cshtml"
                        }
                        else if (message.Type == Models.ChatMessage.Types.Sender)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <div class=\"outgoing_msg\">\r\n                                <div class=\"sent_msg\">\r\n                                    <p>");
#nullable restore
#line 36 "C:\Users\vthan\Downloads\SU22_PRN2212\SU22_PRN2212\SU22_PRN221\Pages\Messages\Index.cshtml"
                                  Write(message.Content);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                                    <span class=\"time_date\">");
#nullable restore
#line 37 "C:\Users\vthan\Downloads\SU22_PRN2212\SU22_PRN2212\SU22_PRN221\Pages\Messages\Index.cshtml"
                                                       Write(message.Created.ToLocalTime());

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                                </div>\r\n                            </div>\r\n");
#nullable restore
#line 40 "C:\Users\vthan\Downloads\SU22_PRN2212\SU22_PRN2212\SU22_PRN221\Pages\Messages\Index.cshtml"
                        }
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </div>\r\n                \r\n            </div>\r\n            <div class=\"type_msg\">\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "47e39a65a5ea0a8fabd2b1f6eee0125e0e0ff63c8434", async() => {
                WriteLiteral("\r\n                        <input type=\"text\" class=\"write_msg\" placeholder=\"Type a message\" />\r\n                        <button class=\"msg_send_btn\" type=\"submit\"><i class=\"fa fa-paper-plane\" aria-hidden=\"true\"></i></button>\r\n                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "47e39a65a5ea0a8fabd2b1f6eee0125e0e0ff63c10463", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
    <script>
        const chatConnection = new signalR.HubConnectionBuilder().withUrl(""/chatHub"").build();
        chatConnection.start().then(function() {

        }).catch(function() {

            console.log(""Connected to chathub failed!..."");
        });



        function scrollToEnd() {
            let box = document.getElementById(""msg_history"");
            box.scrollTop = box.scrollHeight;
        }

        var InComingMessage = (img, content, time) => {
            return `
                    <div class=""incoming_msg"">
                        <div class=""received_msg"">
                        <div class=""received_withd_msg"">
                            <p>${content}</p>
                            <span class=""time_date"">${time}</span></div>
                        </div>
                    </div>
                `;
        }

        var OutGoingMessage = (content, time) => {
            return `
                    <div class=""outgoing_msg"">
                 ");
                WriteLiteral(@"       <div class=""sent_msg"">
                        <p>${content}</p>
                        <span class=""time_date"">${time}</span> </div>
                    </div>
                `;
        }

        function SendMessage(content) {
            fetch("""", {
                method: ""POST"",
                headers: {
                    ""Content-Type"": ""application/json"",
                    ""RequestVerificationToken"": $('input:hidden[name=""__RequestVerificationToken""]').val(),
                },
                body: JSON.stringify(
                    content
                ),
            });
        }

        chatConnection.on(""receiveMessage"", function(message) {
            console.log(message);
            if (message.type == 0) {

                let html = OutGoingMessage(message.content, message.time);
                console.log(html);
                $(""#msg_history"").append(html);
            }
            else if (message.type == 1) {
                $(""#msg_hist");
                WriteLiteral(@"ory"").append(InComingMessage(message.img, message.content, message.time));
            }

            scrollToEnd();
        });

        $(""#chat-form"").submit(function(e) {
            e.preventDefault();

            let content = $("".write_msg"").val();
            if (content.trim()) {
                SendMessage(content);
            }

            $("".write_msg"").val("""");
        });

        scrollToEnd();

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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SU22_PRN221.Pages.Messages.IndexModel> Html { get; private set; } = default!;
        #nullable disable
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<SU22_PRN221.Pages.Messages.IndexModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<SU22_PRN221.Pages.Messages.IndexModel>)PageContext?.ViewData;
        public SU22_PRN221.Pages.Messages.IndexModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591

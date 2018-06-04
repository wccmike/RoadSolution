
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebUI.Login" %>
  <!DOCTYPE html>
  <html>

  <head runat="server">
    <meta http-equiv="Content-Type"
      content="text/html; charset=utf-8" />
    <title>新城区路长系统</title>
    <link href="assets/css/style.css"
      rel="stylesheet"
      type="text/css" />
    <link rel="stylesheet"
      href="assets/css/mainst.css">
    <script src="assets/js/jquery.js"></script>
    <script src="assets/js/cloud.js"></script>
    <script>
      $(function() {
        $('.loginbox').css({
          'position': 'absolute',
          'left': ($(window).width() - 692) / 2
        });
        $(window).resize(function() {
          $('.loginbox').css({
            'position': 'absolute',
            'left': ($(window).width() - 692) /
              2
          });
        });
        $(".loginbtn").bind("click", function() {
          var loginuser = $(".loginuser").val();
          if (loginuser == "") {
            alert("请输入用户名");
            return;
          }
          // document.cookie = "name=" + loginuser;
          // window.location.href = "main.html";
        });
      });
    </script>
  </head>

  <body style="background-color: #1c77ac; background-image: url(assets/images/light.png); background-repeat: no-repeat; background-position: center top; overflow: hidden;">
    <form id="form1"
      runat="server"
      method="post">
      <div id="mainBody">
        <div id="cloud1"
          class="cloud"></div>
        <div id="cloud2"
          class="cloud"></div>
      </div>
      <div class="logintop"> <span>欢迎登录新城区路长管理平台</span>
        <ul>
          <li><a href="#">帮助</a></li>
          <li><a href="#">关于</a></li>
        </ul>
      </div>
      <div class="loginbody">
        <%--无用户或密码错误--%>
          <div id="mes">
            <p id="parname"
              runat="server"></p>
          </div> <span class="systemlogo"></span>
          <div class="loginbox">
            <ul>
              <%-- <li><input type="text" name="uname" class="loginuser" onclick="JavaScript: this.value = ''"/></li>--%>
                <li>
                  <asp:TextBox ID="uname"
                    runat="server"
                    CssClass="loginuser"
                    AutoCompleteType="Disabled"></asp:TextBox>
                </li>
                <li>
                  <%--<input type="text" name="pwd"  class="loginpwd" onclick="JavaScript: this.value = ''"/>--%>
                    <asp:TextBox ID="pwd"
                      runat="server"
                      CssClass="loginpwd"
                      AutoCompleteType="Disabled"
                      TextMode="Password"></asp:TextBox>
                </li>
                <li>
                  <asp:DropDownList ID="DLType"
                    runat="server"></asp:DropDownList>
                  <%--<input type="button" class="loginbtn" value="登录" action="MainPage.aspx"/>--%>
                    <asp:Button ID="btnLogin"
                      runat="server"
                      Text="登录"
                      CssClass="loginbtn"
                      OnClick="btnLogin_Click" />
                    <asp:HyperLink ID="HLRegister"
                      runat="server"
                      NavigateUrl="~/Register.html">注册</asp:HyperLink>
                </li>
                <li> <label>
                            <%--<input name="" type="checkbox" value="" checked="checked" />--%>
                            <asp:CheckBox ID="CheckBox1" runat="server" Text="记住密码" /></label><label><a href="#">忘记密码？</a></label></li>
            </ul>
          </div>
      </div>
      <div class="loginbm"></div>
    </form>
  </body>

  </html>
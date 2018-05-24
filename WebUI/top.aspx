<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="top.aspx.cs" Inherits="WebUI.top" %>

<!DOCTYPE html>

    <html lang="zh"
  xml:lang="zh">
<head runat="server">

  <meta http-equiv="Content-Type"
    content="text/html; charset=utf-8" />
  <meta http-equiv="X-UA-Compatible"
    content="IE=edge" />
  <meta name="viewport"
    content="initial-scale=1.0, user-scalable=no, width=device-width"
  />
  <meta http-equiv="Pragma"
    content="no-cache" />
  <meta http-equiv="Cache-Control"
    content="no-cache" />
  <meta http-equiv="Expires"
    content="-1" />
  <title>无标题文档</title>
  <link href="assets/css/style.css"
    rel="stylesheet"
    type="text/css" />
  <link rel="stylesheet"
    href="assets/css/mybootstrap.css">
  <script language="JavaScript"
    src="assets/js/jquery.js"></script>
  <script src="assets/js/jquerysession.js"></script>
  <script type="text/javascript">
      $(function () {
          //顶部导航切换
          $(".nav li a").click(function () {
              $(".nav li a.selected").removeClass(
                "selected")
              $(this).addClass("selected");
          })
          //取SESSION中的USERNAME
          // var asdf = $.Session.get('user');
          // $("#username").text($.Session.get('user'));
          show = function () {
              //导航切换
              $(".menuson li").click(function () {
                  $(".menuson li.active").removeClass(
                    "active")
                  $(this).addClass("active");
              });
              $('.title').click(function () {
                  var $ul = $(this).next('ul');
                  $('dd').find('ul').slideUp();
                  if ($ul.is(':visible')) {
                      $(this).next('ul').slideUp();
                  } else {
                      $(this).next('ul').slideDown();
                  }
              });
          }
      });
  </script>

</head>
<body style="background:url(assets/images/topbg.gif) repeat-x;">

    <form id="form1" runat="server">
    <div>
    
  <div class="topleft"
    style="padding-top: 30px;"> <a href="main.html"
      target="_parent"
      style="font-size: 28px; margin-left: 20px; color: black;">新城区路长制管理系统</a>    </div>
  <ul class="nav">
    <li> <a href="monitor.html"
        target="rightFrame"
        class="selected">
                <img src="assets/images/icon02.png" title="管护派单" />
                <h2>地图管理</h2>
            </a> </li>
    <li> <a href="15-1.html"
        target="rightFrame"><img src="assets/images/icon04.png" title="实时监管" /><h2>上传资料管理</h2></a>      </li>
    <li><a href="13-01.html"
        target="rightFrame"><img src="assets/images/icon03.png" title="管护报告" /><h2>考勤管理</h2></a></li>
    <li><a href="14-1.html"
        target="rightFrame"><img src="assets/images/icon05.png" title="考核统计" /><h2>统计报告</h2></a></li>
    <li><a href="15-1.html"
        target="rightFrame"><img src="assets/images/103.png" title="数据报表" /><h2>人员管理</h2></a></li>
    <li> <a href="dept.html"
        target="rightFrame">
                <img src="assets/images/icon06.png" title="系统管理" />
                <h2>系统管理</h2>
            </a> </li>
    <li> <a href="empDetail.html"
        target="rightFrame">
                <img src="assets/images/icon06.png" title="个人信息修改" />
                <h2>个人信息修改</h2>
            </a> </li>
    <li> <a href="msgpush.html"
        target="rightFrame">
                <img src="assets/images/icon06.png" title="新消息通知" />
                <h2>新消息通知</h2>
            </a> </li>
  </ul>
  <lable class="usernametext"
    id="username">欢迎你， </lable> 
        <asp:Label  ID="LblUsername" runat="server" Text="" CssClass="usernametext"></asp:Label>
        <asp:HyperLink ID="HlkLogout" runat="server" NavigateUrl="~/Login.aspx" Target="_parent" OnUnload="HlkLogout_Unload" CssClass="usernametext">注销</asp:HyperLink>
    </div>
    </form>
</body>
</html>

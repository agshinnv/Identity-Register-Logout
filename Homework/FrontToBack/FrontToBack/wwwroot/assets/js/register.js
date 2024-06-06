$(function () {
    $(".right-side li .content").click(function (e) {
      e.preventDefault();
      $(this).next().toggleClass("content-menu-down");
      $(this)
        .parent()
        .siblings()
        .find(".content-menu")
        .removeClass("content-menu-down");
    });
  
    var $topBtn = $(".back-to-top");
    $topBtn.hide();
  
    $(window).on("scroll", function () {
      if ($(this).scrollTop() > 100) {
        $topBtn.fadeIn();
      } else {
        $topBtn.fadeOut();
      }
    });
  
    $topBtn.on("click", function (e) {
      e.preventDefault();
      $("html, body").animate({ scrollTop: 0 }, 100);
    });
  });
  
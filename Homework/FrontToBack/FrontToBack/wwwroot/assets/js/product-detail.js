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

  $(".selecting-prd-image .image-1").click(function(){
    $(".active-prd-image .img1").removeClass("d-none");
    $(".active-prd-image .img2").addClass("d-none");
    $(".active-prd-image .img3").addClass("d-none");
    $(".active-prd-image .img4").addClass("d-none");
  })

  $(".selecting-prd-image .image-2").click(function(){
    $(".active-prd-image .img1").addClass("d-none");
    $(".active-prd-image .img2").removeClass("d-none");
    $(".active-prd-image .img3").addClass("d-none");
    $(".active-prd-image .img4").addClass("d-none");
  })

  $(".selecting-prd-image .image-3").click(function(){
    $(".active-prd-image .img1").addClass("d-none");
    $(".active-prd-image .img2").addClass("d-none");
    $(".active-prd-image .img3").removeClass("d-none");
    $(".active-prd-image .img4").addClass("d-none");
  })

  $(".selecting-prd-image .image-4").click(function(){
    $(".active-prd-image .img1").addClass("d-none");
    $(".active-prd-image .img2").addClass("d-none");
    $(".active-prd-image .img3").addClass("d-none");
    $(".active-prd-image .img4").removeClass("d-none");
  })



  $(".product-details .desc-tab button").click(function(){
    $(".description").removeClass("d-none");
    $(".additional").addClass("d-none");
    $(".reviews").addClass("d-none");
    $(".desc-line").removeClass("d-none");
    $(".info-line").addClass("d-none");
    $(".rev-line").addClass("d-none");
  })

  $(".product-details .info-tab button").click(function(){
    $(".description").addClass("d-none");
    $(".additional").removeClass("d-none");
    $(".reviews").addClass("d-none");
    $(".desc-line").addClass("d-none");
    $(".info-line").removeClass("d-none");
    $(".rev-line").addClass("d-none");
  })

  $(".product-details .review-tab button").click(function(){
    $(".description").addClass("d-none");
    $(".additional").addClass("d-none");
    $(".reviews").removeClass("d-none");
    $(".desc-line").addClass("d-none");
    $(".info-line").addClass("d-none");
    $(".rev-line").removeClass("d-none");
  })

});



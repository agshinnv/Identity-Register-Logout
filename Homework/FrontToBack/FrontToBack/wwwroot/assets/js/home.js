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

  $(".searching .selecting").click(function () {
    $(this).children().first().toggleClass("rotate");
    $(this).next().toggleClass("search-down");
    $(this)
      .parent()
      .siblings()
      .find(".selecting-menu")
      .removeClass("search-down");
  });

  $(".all-categories").click(function (e) {
    e.preventDefault();
    $(".categories").toggleClass("d-none");
  });

  // $(".products-icon").hover(function(e){
  //     e.preventDefault(e);
  //     $(".additional-navbar").toggleClass("d-none")
  // })

  $(".products-icon").mouseover(function (e) {
    e.preventDefault();
    $(".additional-navbar").addClass("open");
    $(".additional-navbar").removeClass("d-none");
    $(".additional-navbar").removeClass("close");
  });

  $(".products-icon").mouseout(function (e) {
    e.preventDefault();
    $(".additional-navbar").removeClass("open");
    $(".additional-navbar").addClass("d-none");
    $(".additional-navbar").addClass("close");
  });

  $("#slider .arrows .left").click(function (e) {
    e.preventDefault();
    let activeSlider = $(".active-slider");
    let activeImage = $(".active-image");
    let activeDot = $(".active-dot");

    if (
      activeSlider.prev().length == 0 &&
      activeImage.prev().length == 0 &&
      activeDot.prev().length == 0
    ) {
      return;
    } else {
      activeSlider.removeClass("active-slider");
      activeSlider.prev().addClass("active-slider");
      activeImage.removeClass("active-image");
      activeImage.prev().addClass("active-image");
      activeDot.removeClass("active-dot");
      activeDot.prev().addClass("active-dot");
    }
  });

  $("#slider .arrows .right").click(function (e) {
    e.preventDefault();
    let activeSlider = $(".active-slider");
    let activeImage = $(".active-image");
    let activeDot = $(".active-dot");

    if (
      activeSlider.next().length == 0 &&
      activeImage.next().length == 0 &&
      activeDot.next().length == 0
    ) {
      return;
    } else {
      activeSlider.removeClass("active-slider");
      activeSlider.next().addClass("active-slider");
      activeImage.removeClass("active-image");
      activeImage.next().addClass("active-image");
      activeDot.removeClass("active-dot");
      activeDot.next().addClass("active-dot");
    }
  });

  $("#slider .pages .first-dot").click(function () {
    $(this).addClass("active-dot");
    $(this).siblings().removeClass("active-dot");
    $(".first-slider").addClass("active-slider");
    $(".first-slider").siblings().removeClass("active-slider");
    $(".first-slider-image").addClass("active-image");
    $(".first-slider-image").siblings().removeClass("active-image");
  });

  $("#slider .pages .second-dot").click(function () {
    $(this).addClass("active-dot");
    $(this).siblings().removeClass("active-dot");
    $(".second-slider").addClass("active-slider");
    $(".second-slider").siblings().removeClass("active-slider");
    $(".second-slider-image").addClass("active-image");
    $(".second-slider-image").siblings().removeClass("active-image");
  });

  $("#slider .pages .third-dot").click(function () {
    $(this).addClass("active-dot");
    $(this).siblings().removeClass("active-dot");
    $(".third-slider").addClass("active-slider");
    $(".third-slider").siblings().removeClass("active-slider");
    $(".third-slider-image").addClass("active-image");
    $(".third-slider-image").siblings().removeClass("active-image");
  });

  $("#products .product-category .new-product").click(function (e) {
    e.preventDefault();
    $(this).addClass("active");
    $("#products .product-category .featured-product").removeClass("active");
    $("#products .product-category .top-product").removeClass("active");
    $("#products .new-products-list").removeClass("d-none");
    $("#products .featured-products-list").addClass("d-none");
    $("#products .top-products-list").addClass("d-none");
  });

  $("#products .product-category .featured-product").click(function (e) {
    e.preventDefault();
    $(this).addClass("active");
    $("#products .product-category .new-product").removeClass("active");
    $("#products .product-category .top-product").removeClass("active");
    $("#products .new-products-list").addClass("d-none");
    $("#products .featured-products-list").removeClass("d-none");
    $("#products .top-products-list").addClass("d-none");
  });

  $("#products .product-category .top-product").click(function (e) {
    e.preventDefault();
    $(this).addClass("active");
    $("#products .product-category .featured-product").removeClass("active");
    $("#products .product-category .new-product").removeClass("active");
    $("#products .new-products-list").addClass("d-none");
    $("#products .featured-products-list").addClass("d-none");
    $("#products .top-products-list").removeClass("d-none");
  });

  $("#slider-2-tablet .pages .first-dot").click(function () {
    $(this).addClass("active-dot");
    $(this).siblings().removeClass("active-dot");
    $(".first-slider").addClass("active-slider");
    $(".first-slider").siblings().removeClass("active-slider");
    $(".first-image").addClass("active-image");
    $(".first-image").siblings().removeClass("active-image");
  });

  $("#slider-2-tablet .pages .second-dot").click(function () {
    $(this).addClass("active-dot");
    $(this).siblings().removeClass("active-dot");
    $(".second-slider").addClass("active-slider");
    $(".second-slider").siblings().removeClass("active-slider");
    $(".second-image").addClass("active-image");
    $(".second-image").siblings().removeClass("active-image");
  });

  $("#slider-2-tablet .pages .third-dot").click(function () {
    $(this).addClass("active-dot");
    $(this).siblings().removeClass("active-dot");
    $(".third-slider").addClass("active-slider");
    $(".third-slider").siblings().removeClass("active-slider");
    $(".third-image").addClass("active-image");
    $(".third-image").siblings().removeClass("active-image");
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

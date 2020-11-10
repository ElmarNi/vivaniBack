$(document).ready(function () {
  jQuery.fn.clickOutside = function (callback) {
    var $me = this;
    $(document).mouseup(function (e) {
      if (!$me.is(e.target) && $me.has(e.target).length === 0) {
        callback.apply($me);
      }
    });
  };
  
  $('#slider .owl-carousel').owlCarousel({
    loop: true,
    margin: 0,
    items: 1,
    dots: true,
    nav: true,
    autoplay: true,
    autoplayTimeout: 5000,
    autoplayHoverPause: true
  });
  $("#small-screens .menu-bar i.open-menu").click(function (e) {
    $(this).toggleClass("fa-times");
    $("#small-screens nav").slideToggle()
  });
  $('#small-screens').clickOutside(function () {
    $(this).find("nav").slideUp()
    $("#small-screens .menu-bar i.open-menu").removeClass("fa-times");
  });
  $("#popular-products .categories a").click(function (e) {
    e.preventDefault();
    $("#popular-products .categories a.active").removeClass("active")
    $(this).addClass("active")
    $("#popular-products .row.content.active").hide().removeClass("active")
    $(`#popular-products .row[data-id="${$(this).attr("data-id")}"]`).show().addClass("active")
  })
  $("#clients .owl-carousel").owlCarousel({
    dots:true,
    loop: true,
    nav: false,
    autoplay: true,
    autoplayTimeout: 5000,
    autoplayHoverPause: true,
    responsive:{
      0:{
          items:1
      },
      768:{
          items:2
      },
      991:{
          items:3
      }
  }
  });
});
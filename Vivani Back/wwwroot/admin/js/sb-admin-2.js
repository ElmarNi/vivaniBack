(function($) {
  "use strict"; // Start of use strict

  // Toggle the side navigation
  $("#sidebarToggle, #sidebarToggleTop").on('click', function(e) {
    $("body").toggleClass("sidebar-toggled");
    $(".sidebar").toggleClass("toggled");
    if ($(".sidebar").hasClass("toggled")) {
      $('.sidebar .collapse').collapse('hide');
    };
  });

  // Close any open menu accordions when window is resized below 768px
  $(window).resize(function() {
    if ($(window).width() < 768) {
      $('.sidebar .collapse').collapse('hide');
    };
    
    // Toggle the side navigation when window is resized below 480px
    if ($(window).width() < 480 && !$(".sidebar").hasClass("toggled")) {
      $("body").addClass("sidebar-toggled");
      $(".sidebar").addClass("toggled");
      $('.sidebar .collapse').collapse('hide');
    };
  });

  // Prevent the content wrapper from scrolling when the fixed side navigation hovered over
  $('body.fixed-nav .sidebar').on('mousewheel DOMMouseScroll wheel', function(e) {
    if ($(window).width() > 768) {
      var e0 = e.originalEvent,
        delta = e0.wheelDelta || -e0.detail;
      this.scrollTop += (delta < 0 ? 1 : -1) * 30;
      e.preventDefault();
    }
  });

  // Scroll to top button appear
  $(document).on('scroll', function() {
    var scrollDistance = $(this).scrollTop();
    if (scrollDistance > 100) {
      $('.scroll-to-top').fadeIn();
    } else {
      $('.scroll-to-top').fadeOut();
    }
  });

  // Smooth scrolling using jQuery easing
  $(document).on('click', 'a.scroll-to-top', function(e) {
    var $anchor = $(this);
    $('html, body').stop().animate({
      scrollTop: ($($anchor.attr('href')).offset().top)
    }, 1000, 'easeInOutExpo');
    e.preventDefault();
  });
    function change_img(input, image) {
        $(input).change(function () {
            let input = this;
            let url = $(this).val();
            let ext = url.substring(url.lastIndexOf('.') + 1).toLowerCase();
            if (input.files && input.files[0] && (ext == "gif" || ext == "png" || ext == "jpeg" || ext == "jpg")) {
                var reader = new FileReader();

                reader.onload = function (e) {
                    $(image).attr('src', e.target.result);
                }
                reader.readAsDataURL(input.files[0]);
            }
        })
    }
    change_img("#whyChooseUsAdmin #IconImage", "#whyChooseUsAdmin .newImage img");
    change_img("#adminAbout #Image", "#adminAbout .newImage img");
    change_img("#contactAdmin #Image", "#contactAdmin .newImage img");

    $(document).on('click', '#contactMessagesAdmin button', function (e) {
        $("#fullMessageInfo p.isResponsed").text($(this).parent().prev().text())
        $("#fullMessageInfo p.date").text($(this).parent().prev().prev().text())
        $("#fullMessageInfo p.phoneNumber").text($(this).parent().prev().prev().prev().prev().text())
        $("#fullMessageInfo p.email").text($(this).parent().prev().prev().prev().prev().prev().text())
        $("#fullMessageInfo p.name").text($(this).parent().prev().prev().prev().prev().prev().prev().text())
        $("#fullMessageInfo p.message").text($(this).parent().prev().prev().prev().attr("data-message"))
        $("#fullMessageInfo").attr("data-id", $(this).attr("data-id"))
    });
    
})(jQuery); // End of use strict

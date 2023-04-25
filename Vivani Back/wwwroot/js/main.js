$(document).ready(function () {
  jQuery.fn.clickOutside = function (callback) {
    var $me = this;
    $(document).mouseup(function (e) {
      if (!$me.is(e.target) && $me.has(e.target).length === 0) {
        callback.apply($me);
      }
    });
  };

    $(window).scroll(function (e) {
        if ($(window).scrollTop() > 200) $("#toTop").fadeIn("slow")
        else $("#toTop").fadeOut("slow")
    });

    if ($(window).scrollTop() > 200) $("#toTop").fadeIn("slow")
    else $("#toTop").fadeOut("slow")

    $("#toTop").click(function (e) {
        e.preventDefault();
        window.scrollTo({ top: 0, behavior: 'smooth' });
    })

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
    if ($("#contact .successText").text() != "") {
        $([document.documentElement, document.body]).animate({
            scrollTop: $(".form-cont").offset().top
        }, 0);
        setTimeout(() =>
            {
                $("#contact .successText").text("")
            }, 5000
        );
    }
    function controlFromInput(fromSlider, fromInput, toInput, controlSlider) {
        const [from, to] = getParsed(fromInput, toInput);
        fillSlider(fromInput, toInput, '#C6C6C6', '#ead2ac', controlSlider);
        if (from > to) {
            fromSlider.value = to;
            fromInput.value = to;
        } else {
            fromSlider.value = from;
        }
    }

    function controlToInput(toSlider, fromInput, toInput, controlSlider) {
        const [from, to] = getParsed(fromInput, toInput);
        fillSlider(fromInput, toInput, '#C6C6C6', '#ead2ac', controlSlider);
        setToggleAccessible(toInput);
        if (from <= to) {
            toSlider.value = to;
            toInput.value = to;
        } else {
            toInput.value = from;
        }
    }

    function controlFromSlider(fromSlider, toSlider, fromInput) {
        const [from, to] = getParsed(fromSlider, toSlider);
        fillSlider(fromSlider, toSlider, '#C6C6C6', '#ead2ac', toSlider);
        if (from > to) {
            fromSlider.value = to;
            fromInput.value = to;
        } else {
            fromInput.value = from;
        }
    }

    function controlToSlider(fromSlider, toSlider, toInput) {
        const [from, to] = getParsed(fromSlider, toSlider);
        fillSlider(fromSlider, toSlider, '#C6C6C6', '#ead2ac', toSlider);
        setToggleAccessible(toSlider);
        if (from <= to) {
            toSlider.value = to;
            toInput.value = to;
        } else {
            toInput.value = from;
            toSlider.value = from;
        }
    }

    function getParsed(currentFrom, currentTo) {
        const from = parseInt(currentFrom.value, 10);
        const to = parseInt(currentTo.value, 10);
        return [from, to];
    }

    function fillSlider(from, to, sliderColor, rangeColor, controlSlider) {
        const rangeDistance = to.max - to.min;
        const fromPosition = from.value - to.min;
        const toPosition = to.value - to.min;
        controlSlider.style.background = `linear-gradient(
      to right,
      ${sliderColor} 0%,
      ${sliderColor} ${(fromPosition) / (rangeDistance) * 100}%,
      ${rangeColor} ${((fromPosition) / (rangeDistance)) * 100}%,
      ${rangeColor} ${(toPosition) / (rangeDistance) * 100}%, 
      ${sliderColor} ${(toPosition) / (rangeDistance) * 100}%, 
      ${sliderColor} 100%)`;
    }

    function setToggleAccessible(currentTarget) {
        const toSlider = document.querySelector('#toSlider');
        if (Number(currentTarget.value) <= 0) {
            toSlider.style.zIndex = 2;
        } else {
            toSlider.style.zIndex = 0;
        }
    }

    const fromSlider = document.querySelector('#fromSlider');
    const toSlider = document.querySelector('#toSlider');
    const fromInput = document.querySelector('#fromInput');
    const toInput = document.querySelector('#toInput');
    if (fromSlider != null && toSlider != null && fromInput != null && toInput != null) {
        fillSlider(fromSlider, toSlider, '#C6C6C6', '#ead2ac', toSlider);
        setToggleAccessible(toSlider);

        fromSlider.oninput = () => controlFromSlider(fromSlider, toSlider, fromInput);
        toSlider.oninput = () => controlToSlider(fromSlider, toSlider, toInput);
        fromInput.oninput = () => controlFromInput(fromSlider, fromInput, toInput, toSlider);
        toInput.oninput = () => controlToInput(toSlider, fromInput, toInput, toSlider);
    }
    $("#trending .products img").each(function (index, element) {
        let height = $("#trending .products").prev().find("img").height() == 0 ? 600 : $("#trending .products").prev().find("img").height()
        if (window.innerWidth > 992) $(this).height((height / 2) - $(this).parent().parent().next().height() - 46)
        else $(this).height(166)
    })
    $(window).resize(function () {
        $("#trending .products img").each(function (index, element) {
            let height = $("#trending .products").prev().find("img").height() == 0 ? 200 : $("#trending .products").prev().find("img").height()
            if (window.innerWidth > 992) $(this).height((height / 2) - $(this).parent().parent().next().height() - 46)
            else $(this).height(166)
        })
    })
});
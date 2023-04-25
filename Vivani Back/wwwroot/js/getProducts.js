$(document).on("click", "#products .page-item", function (e) {
    e.preventDefault()
    if ($(this).hasClass("disabled")) return
    let page = $(this).text()
    $("#products .page-item.active").removeClass("active")
    if ($(this)[0] == $("#products .page-item:first-child")[0]) page = $("#products .page-item:first-child").next().text()
    if ($(this)[0] == $("#products .page-item:last-child")[0]) page = $("#products .page-item:last-child").prev().text()

    window.scrollTo({ top: 0, behavior: 'smooth' });
    
    getProducts(page)

});


$("#products .search").click(async function (e) {
    e.preventDefault();
    getProducts(1)
})

function getProducts(page) {
    let categoryIds = []
    let typeIds = []
    let min = $("#products #fromInput").val();
    let max = $("#products #toInput").val();

    $("#products ul.categories input:checked").each(function () {
        categoryIds.push($(this).attr("data-id"))
    })

    $("#products ul.types input:checked").each(function () {
        typeIds.push($(this).attr("data-id"))
    })

    if (categoryIds.length == 0) {
        $("#products ul.categories input").each(function () {
            categoryIds.push($(this).attr("data-id"))
        })
    }

    if (typeIds.length == 0) {
        $("#products ul.types input").each(function () {
            typeIds.push($(this).attr("data-id"))
        })
    }

    $.ajax({
        url: "/GetProductsAjax/getProducts/",
        type: "POST",
        data: {
            "categoryIds": categoryIds,
            "typeIds": typeIds,
            "min": min,
            "max": max,
            "page": page
        },
        beforeSend: function () {
            $("#products .right-side").html("<img class='loadingGif' src='img/loadingGif.gif' />")
        },
        success: function (res) {
            $("#products .right-side").html(res)
        }
    })
}
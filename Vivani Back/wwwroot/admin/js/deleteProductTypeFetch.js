$(document).on('click', '#productTypeAdminIndex .openConfirmationModal', function (e) {
    console.log($(this).parent().prev().prev().prev().find("img"))
    $("#confirmationModal").attr("data-id", $(this).attr("data-id"))
});

$("#productTypeAdminIndex button.deleteCategory").click(async function (e) {
    e.preventDefault();
    let id = $("#confirmationModal").attr("data-id")
    await getResponse(id)
    setTimeout(() => { $("#productTypeAdminIndex .textSuccess").text("") }, 5000);
});

async function getResponse(id) {
    const request = await fetch(
        '/fetch/deleteType/' + id,
        {
            method: 'POST'
        }
    );
    const response = await request.text()
    if (response === "true") {
        $(`#productTypeAdminIndex tr[data-id="${id}"]`).remove()
        $("#productTypeAdminIndex .textSuccess").removeClass("text-danger").addClass("text-success").text("Əyar uğurla silindi")
    }
    else
        $("#productTypeAdminIndex .textSuccess").removeClass("text-success").addClass("text-danger").text("Əyar silinmmədi !")
}
$(document).on('click', '#productCategoryAdminIndex .openConfirmationModal', function (e) {
    console.log($(this).parent().prev().prev().prev().find("img"))
    $("#confirmationModal").attr("data-id", $(this).attr("data-id"))
});

$("#productCategoryAdminIndex button.deleteCategory").click(async function (e) {
    e.preventDefault();
    let id = $("#confirmationModal").attr("data-id")
    await getResponse(id)
    setTimeout(() => { $("#productCategoryAdminIndex .textSuccess").text("") }, 5000);
});

async function getResponse(id) {
    const request = await fetch(
        '/fetch/deleteCategory/' + id,
        {
            method: 'POST'
        }
    );
    const response = await request.text()
    if (response === "true") {
        $(`#productCategoryAdminIndex tr[data-id="${id}"]`).remove()
        $("#productCategoryAdminIndex .textSuccess").removeClass("text-danger").addClass("text-success").text("Kateqoriya uğurla silindi")
    }
    else
        $("#productCategoryAdminIndex .textSuccess").removeClass("text-success").addClass("text-danger").text("Kateqoriya silinmmədi !")
}
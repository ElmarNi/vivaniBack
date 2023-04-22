$(document).on('click', '#productUpdateAdmin .openConfirmationModal', function (e) {
    console.log($(this).next())
    $("#confirmationModal .modal-body").html(`
        <img src = '${$(this).next().attr('src')}' class = 'img-fluid' />
        <p class = 'm-0'>Şəkli silməyə əminsiniz?</p>
    `)
    $("#confirmationModal").attr("data-id", $(this).attr("data-id"))
});

$("#productUpdateAdmin button.deleteCategory").click(async function (e) {
    e.preventDefault();
    let id = $("#confirmationModal").attr("data-id")
    await getResponse(id)
    setTimeout(() => { $("#productUpdateAdmin .textSuccess").text("") }, 5000);
});

async function getResponse(id) {
    const request = await fetch(
        '/fetch/deleteProductImage/' + id,
        {
            method: 'POST'
        }
    );
    const response = await request.text()
    if (response === "true") {
        $(`#productUpdateAdmin .img-wrapper i[data-id="${id}"]`).parent().remove()
        $("#productUpdateAdmin .textSuccess").removeClass("text-danger").addClass("text-success").text("Şəkil uğurla silindi")
    }
    else
        $("#productUpdateAdmin .textSuccess").removeClass("text-success").addClass("text-danger").text("Şəkil silinmmədi !")
}
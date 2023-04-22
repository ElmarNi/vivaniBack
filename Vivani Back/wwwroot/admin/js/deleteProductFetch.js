$(document).on('click', '#productAdminIndex .openConfirmationModal', function (e) {
    $(this).parent().parent().find("img")
    

    $("#confirmationModal .modal-body").html(`
        <img src = '${$(this).parent().parent().find("img").attr('src')}' class = 'img-fluid' />
        <p class = 'm-0'>${$(this).parent().parent().find("td")[1].innerText} adlı məhsulu silməyə əminsiniz?</p>
    `)
    $("#confirmationModal").attr("data-id", $(this).attr("data-id"))
});

$("#productAdminIndex button.deleteCategory").click(async function (e) {
    e.preventDefault();
    let id = $("#confirmationModal").attr("data-id")
    await getResponse(id)
    setTimeout(() => { $("#productAdminIndex .textSuccess").text("") }, 5000);
});

async function getResponse(id) {
    const request = await fetch(
        '/fetch/deleteProduct/' + id,
        {
            method: 'POST'
        }
    );
    const response = await request.text()
    if (response === "true") {
        $(`#productAdminIndex tr[data-id="${id}"]`).remove()
        $("#productAdminIndex .textSuccess").removeClass("text-danger").addClass("text-success").text("Məhsul uğurla silindi")
    }
    else
        $("#productAdminIndex .textSuccess").removeClass("text-success").addClass("text-danger").text("Məhsul silinmmədi !")
}
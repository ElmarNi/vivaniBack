$(document).on('click', '#homeSliderAdminIndex .openConfirmationModal', function (e) {
    console.log($(this).parent().prev().prev().prev().find("img"))
    $("#confirmationModal img").attr("src", $(this).parent().prev().prev().prev().find("img").attr("src"))
    $("#confirmationModal").attr("data-id", $(this).attr("data-id"))
});

$("#homeSliderAdminIndex button.deleteSlider").click(async function (e) {
    e.preventDefault();
    let id = $("#confirmationModal").attr("data-id")
    await getResponse(id)
    setTimeout(() => { $("#homeSliderAdminIndex .textSuccess").text("") }, 5000);
});

async function getResponse(id) {
    const request = await fetch(
        '/fetch/deleteSlider/' + id,
        {
            method: 'POST'
        }
    );
    const response = await request.text()
    if (response === "true") {
        $(`#homeSliderAdminIndex tr[data-id="${id}"]`).remove()
        $("#homeSliderAdminIndex .textSuccess").removeClass("text-danger").addClass("text-success").text("Slayder uğurla silindi")
    }
    else
        $("#homeSliderAdminIndex .textSuccess").removeClass("text-success").addClass("text-danger").text("Slayder silinmmədi !")
}
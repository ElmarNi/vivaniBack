$("#contactMessagesAdmin a.updateStatus").click(async function (e) {
    e.preventDefault();
    let id = $(this).attr("data-id")
    if (await getResponse(id, false)) {
        if ($(this).parent().prev().text() == "HƏ") $(this).parent().prev().text("YOX")
        else $(this).parent().prev().text("HƏ")
    }
    setTimeout(() => {
            $("#contactMessagesAdmin .textSuccess").text("")
        }, 5000
    );
});

$("#fullMessageInfo button.updateStatus").click(async function (e) {
    e.preventDefault();
    let id = $(this).parent().parent().parent().parent().attr("data-id")
    if (await getResponse(id, true)) {
        if ($(this).parent().prev().find(".isResponsed").text() == "HƏ") {
            $(this).parent().prev().find(".isResponsed").text("YOX")
            $(`#contactMessagesAdmin a[data-id="${id}"]`).parent().prev().text("YOX")
        }
        else {
            $(this).parent().prev().find(".isResponsed").text("HƏ")
            $(`#contactMessagesAdmin a[data-id="${id}"]`).parent().prev().text("HƏ")
        }
    }
    setTimeout(() => {
        $("#fullMessageInfo .textSuccess").text("")
        }, 5000
    );
});

async function getResponse(id, isModal) {
    const request = await fetch(
        '/fetch/updateContactMessageStatus/' + id,
        {
            method: 'POST'
        }
    );
    const response = await request.text()
    let selector = isModal ? "#fullMessageInfo .textSuccess" : "#contactMessagesAdmin .textSuccess"
    if (response === "true") {
        $(selector).removeClass("text-danger").addClass("text-success").text("Status uğurla dəyişdirildi")
        return true;
    }
    else {
        $(selector).removeClass("text-success").addClass("text-danger").text("Status dəyişdirilmədi")
        return false;
    }
}
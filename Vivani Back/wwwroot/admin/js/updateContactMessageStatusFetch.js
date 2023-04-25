$(document).on('click', '#contactMessagesAdmin button', function (e) {
    $("#fullMessageInfo p.name").text($(this).parent().prev().prev().prev().prev().prev().prev().prev().text())
    $("#fullMessageInfo p.email").text($(this).parent().prev().prev().prev().prev().prev().prev().text())
    $("#fullMessageInfo p.phoneNumber").text($(this).parent().prev().prev().prev().prev().prev().text())
    $("#fullMessageInfo p.date").text($(this).parent().prev().prev().text())
    $("#fullMessageInfo p.isResponsed").text($(this).parent().prev().text())
    $("#fullMessageInfo p.showInHome").text($(this).parent().prev().prev().prev().text())
    $("#fullMessageInfo p.message").text($(this).parent().prev().prev().prev().prev().attr("data-message"))
    $("#fullMessageInfo").attr("data-id", $(this).attr("data-id"))
});

$("#contactMessagesAdmin a.updateStatus").click(async function (e) {
    e.preventDefault();
    let id = $(this).attr("data-id")
    if (await changeStatus(id, false)) {
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
    if (await changeStatus(id, true)) {
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

$("#contactMessagesAdmin a.updateHomeStatus").click(async function (e) {
    e.preventDefault();
    let id = $(this).attr("data-id")
    if (await changeShowInHomeStatus(id, false)) {
        if ($(this).parent().prev().prev().prev().text() == "HƏ") $(this).parent().prev().prev().prev().text("YOX")
        else $(this).parent().prev().prev().prev().text("HƏ")
    }
    setTimeout(() => {
        $("#contactMessagesAdmin .textSuccess").text("")
    }, 5000
    );
});

$("#fullMessageInfo button.updateHomeStatus").click(async function (e) {
    e.preventDefault();
    let id = $(this).parent().parent().parent().parent().attr("data-id")
    if (await changeStatus(id, true)) {
        if ($(this).parent().prev().find(".showInHome").text() == "HƏ") {
            $(this).parent().prev().find(".showInHome").text("YOX")
            $(`#contactMessagesAdmin a[data-id="${id}"]`).parent().prev().prev().prev().text("YOX")
        }
        else {
            $(this).parent().prev().find(".showInHome").text("HƏ")
            $(`#contactMessagesAdmin a[data-id="${id}"]`).parent().prev().prev().prev().text("HƏ")
        }
    }
    setTimeout(() => {
        $("#fullMessageInfo .textSuccess").text("")
    }, 5000
    );
});

async function changeStatus(id, isModal) {
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

async function changeShowInHomeStatus(id, isModal) {
    const request = await fetch(
        '/fetch/updateContactMessageShowInHomeStatus/' + id,
        {
            method: 'POST'
        }
    );
    const response = await request.text()
    let selector = isModal ? "#fullMessageInfo .textSuccess" : "#contactMessagesAdmin .textSuccess"
    if (response === "true") {
        $(selector).removeClass("text-danger").addClass("text-success").text("Ana səhifə görsənsin uğurla dəyişdirildi")
        return true;
    }
    else {
        $(selector).removeClass("text-success").addClass("text-danger").text("Ana səhifə görsənsin dəyişdirilmədi")
        return false;
    }
}
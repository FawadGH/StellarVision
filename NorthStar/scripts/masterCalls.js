//Ajax call to server to get count for baloons and msgs (OLD HIT)
//function pollServer() {
//    var msg_count = false;
//    var noti_count = false;

////-------------------------------------------------------------------------------
//        $.ajax({
//            type: "POST",
//            url: "WebForm4.aspx/BaloonAlerts",
//            data: "{}",
//            contentType: "application/json; charset=utf-8;",
//            success: function (result) {
//                if (result.d[0] > 0) {
//                    $('#msg_baloonCount').text(result.d[0]);
//                    $('#msg_baloonCount').show();
//                    $('#msg_header').text('You have ' + result.d[0] + ' messages');
//                    msg_count = true;
//                }
//                else {
//                    $('#msg_header').text('You have 0 messages')
//                    msg_count = false;
//                }

//                if (result.d[1] > 0) {
//                    $('#noti_baloonCount').text(result.d[1]);
//                    $('#noti_baloonCount').show();
//                    $('#noti_header').text('You have ' + result.d[1] + ' notifications');
//                    noti_count = true;
//                }
//                else {
//                    $('#noti_header').text('You have 0 notifications');
//                    noti_count = false;
//                }

//                setTimeout(pollServer, 5000);
//            },
//            error: function (result) {
//                $('#msg_baloonCount').hide();
//                $('#noti_baloonCount').hide();
//                console.log(result.d);
//            }

//        });
////-------------------------------------------------------------------------------
////-------------------------------------------------------------------------------
//    if (msg_count) {
//        //ajax to hit server to get messages
//        $.ajax({
//            type: "POST",
//            contentType: "application/json; charset=utf-8",
//            data: "{}",
//            url: "WebForm4.aspx/Messages",
//            success: function (response) {
//                var message = response.d;
//                $('#msg_highlight').html();
//                $(message).each(function () {
//                    $().html('<li>' +
//                                                  '<a href="#">' +
//                                                      '<div class="pull-left">' +
//                                                          '<img src="../img/man.png" class="img-circle" alt="User Image" />' + //IMAGE URL HERE
//                                                      '</div>' +
//                                                      '<h4 id="msg_heading">' + message.name +  //NAME OF THE SENDER HERE
//                                                      '<small id="msg_time"><i class="fa fa-clock-o"></i>5 mins</small>' +
//                                                      '</h4>' +
//                                                      '<p id="msg_content">' + message.truncatedmsg + '</p>' +  //Truncated Message here
//                                                  '</a>' +
//                                              '</li>');
//                });
//            },
//            error: function () {
//                console.log(result.d);
//            }

//        });
//    }
////-------------------------------------------------------------------------------
////-------------------------------------------------------------------------------
//    if (noti_count) {
//        //ajax to hit server to get notifications, list.
//    }

//}

//Fetch hit to Server side (new)
function pollServer() {

    var msg_count = false;
    var noti_count = false;

    fetch('WebForm4.aspx/BaloonAlerts', {
        method: "POST", headers: { 'Accept': 'application/json, text/plain, */*', 'Content-Type': 'application/json' }
    }).then((resp) => resp.json()).then(function (data) {
        if (data.d[0] > 0) {
            $('#msg_baloonCount').text(data.d[0]);
            $('#msg_baloonCount').show();
            $('#msg_header').text('You have ' + data.d[0] + ' messages');
            msg_count = true;
        }
        else {
            $('#msg_header').text('You have 0 messages')
            msg_count = false;
        }

        if (data.d[1] > 0) {
            $('#noti_baloonCount').text(data.d[1]);
            $('#noti_baloonCount').show();
            $('#noti_header').text('You have ' + data.d[1] + ' notifications');
            noti_count = true;
        }
        else {
            $('#noti_header').text('You have 0 notifications');
            noti_count = false;
        }

        //if (msg_count) {
        //    fetch('WebForm4.aspx/Messages', {
        //        method: "POST",
        //        header: { contentType: "application/json; charset=utf-8;" }
        //    }).then((Msgresp) => Msgresp.json()).then(function (Msgdata) {
        //        if (Msgdata.d != null)
        //        {

        //        }
        //        msg_count = false;
        //    })
        //}

        setTimeout(pollServer, 50000);
    }).catch(function (err) {
        console.log(err)
    });
}


//executes on startup (Updates the count on the baloons) 
//$(pollServer());


//on click of Message and notification, baloon will disappear
$(document).ready(function () {
    $('[data-toggle="tooltip"]').tooltip();
    $('#msg_toggle').on('click', function () {
        $('#msg_baloonCount').hide();
    });

    $('#noti_toggle').on('click', function () {
        $('#noti_baloonCount').hide();
    })
      

    $(function () {
        //$("#PTSS_LOGO").removeClass('PTSS_LOGO_Expand').addClass('PTSS_LOGO_Collapsed');

        if ($("body").hasClass('fixed')) {
            $("#PTSS_LOGO").addClass('PTSS_LOGO_Expand').removeClass('PTSS_LOGO_Collapsed');
        } else {
            $("#PTSS_LOGO").removeClass('PTSS_LOGO_Expand').addClass('PTSS_LOGO_Collapsed');
        }
    });

    $('#Left_menu_toggle_button').on('click', function () {

        if ($("body").hasClass('sidebar-collapse')) {
            $("#PTSS_LOGO").addClass('PTSS_LOGO_Expand').removeClass('PTSS_LOGO_Collapsed');
        } else {
            $("#PTSS_LOGO").removeClass('PTSS_LOGO_Expand').addClass('PTSS_LOGO_Collapsed');
        }

    });

});



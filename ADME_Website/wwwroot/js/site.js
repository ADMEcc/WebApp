function aboutUsPopup() {
    $('#aboutUsModal').modal('show');
}

const words = ["Join the Blockchain Revolution", "Get paid for your time", "Monetize your network", "Become a product owner", "Earn Basic Income", "Buy discounts with your attention"];
let i = 0;
let timer;

function typingEffect() {
    let word = words[i].split("");
    var loopTyping = function () {
        if (word.length > 0) {
            document.getElementById('word').innerHTML += word.shift();
        } else {
            deletingEffect();
            return false;
        };
        timer = setTimeout(loopTyping, 100);
    };
    loopTyping();
};

function deletingEffect() {

    setTimeout(function () {
        let word = words[i].split("");
        var loopDeleting = function () {
            if (word.length > 0) {
                word.pop();
                document.getElementById('word').innerHTML = word.join("");
            } else {
                if (words.length > (i + 1)) {
                    i++;
                } else {
                    i = 0;
                };
                typingEffect();
                return false;
            };
            timer = setTimeout(loopDeleting, 100);
        };
        loopDeleting();
    }, 1000);
};

function pulse() {
    console.log("asd");
    $('#playpause').animate({
        width: '15%', height: '10%', // sets the base height and width
        opacity: 0.5
    }, 700, function () {
        $('#playpause').animate({
            width: '17%', height: '12%', // sets the alternative height and width
            opacity: 1
        }, 700, function () {
            pulse();
                });
        });

}

function setHover() {
    $('.flip-container')
        .css({ 'outline': 'none' })
        .off('mouseover mouseleave click')
        .on({
            mouseover: function () {
                $('.flip-container').css({ '-webkit-box-shadow': 'none', '-moz-box-shadow': 'none', 'box-shadow': 'none' });
            },
            mouseleave: function () {
                $('.flip-container').css({ '-webkit-box-shadow': '0px 4px 12px rgba(0, 0, 0, 0.16)', '-moz-box-shadow': '0px 4px 12px rgba(0, 0, 0, 0.16)' });
            }
        });
}

$(document).ready(function () {
    pulse();
    setHover();

    $("#offering-nav").click(function (event) {
        event.preventDefault();

        $('html, body').animate({
            scrollTop: $("#offering-nav-div").offset().top-200
        }, 1000);
    });

    $("#how-nav").click(function (event) {
        event.preventDefault();

        $('html, body').animate({
            scrollTop: $("#how-nav-div").offset().top - 100
        }, 1000);
    });

    $("#pbbi-nav").click(function (event) {
        event.preventDefault();

        $('html, body').animate({
            scrollTop: $("#pbbi-nav-div").offset().top - 100
        }, 1000);
    });

    $("#profit-nav").click(function (event) {
        event.preventDefault();

        $('html, body').animate({
            scrollTop: $("#profit-nav-div").offset().top - 100
        }, 1000);
    });

    $("#tokenomics-nav").click(function (event) {
        event.preventDefault();

        $('html, body').animate({
            scrollTop: $("#tokenomics-nav-div").offset().top - 50
        }, 1000);
    });

    $("#roadmap-nav").click(function (event) {
        event.preventDefault();

        $('html, body').animate({
            scrollTop: $("#roadmap-nav-div").offset().top - 50
        }, 1000);
    });

    $("#team-nav").click(function (event) {
        event.preventDefault();

        $('html, body').animate({
            scrollTop: $("#team-nav-div").offset().top
        }, 1000);
    });

    $("#token-sale-nav-xs").click(function (event) {
        event.preventDefault();
        var value = "true";
        localStorage.setItem("valueKey", value);

        window.location.href = "/Home/Donate";
    });

    $("#tel-pc").click(function (event) {
        window.open('https://t.me/admecc', '_blank');
    });

    $("#in-pc").click(function (event) {
        window.open('https://www.linkedin.com/company/adme-cc/', '_blank');
    });

    $("#twitter-pc").click(function (event) {
        window.open('https://twitter.com/ADME_official', '_blank');
    });

    $("#git-pc").click(function (event) {
        window.open('https://github.com/ADMEcc/WebApp', '_blank');
    });

    $("#in-mobile").on('click', function () {
        window.open('https://www.linkedin.com/company/adme-cc/', '_blank');
    });

    $("#tel-mobile").on('click', function () {
        window.open('https://t.me/admecc', '_blank');
    });

    $("#twitter-mobile").on('click', function () {
        window.open('https://twitter.com/ADME_official', '_blank');
    });

    $("#git-mobile").on('click', function () {
        window.open('https://github.com/ADMEcc/WebApp', '_blank');
    });

    $("#nav-logo").click(function (event) {
        window.location.href = '/Home/Index';
    });

    //$("#token-sale-nav").click(function () {
    //    event.preventDefault();
    //    window.location.href = "/Home/Donate#token-sale-nav-div";
    //    scroll();
            
    //});

    //function scroll() {
    //    if (window.location.hash !== null && window.location.hash !== '')
    //        $('body').animate({
    //            scrollTop: $(window.location.hash).offset().top
    //        }, 1500);
    //}

    //$('#token-sale-nav').click(function () {
    //    if (location.hash == "#token-sale-nav-div") {
    //        $('html, body').animate({
    //            scrollTop: $("#token-sale-nav-div").offset().top
    //        }, 1000);
    //    }
    //});



    $(window).scroll(function () {
        var scrollPos = $(window).scrollTop(),
            navbar = $('.navbar-custom');

        if (scrollPos > 50) {
            navbar.addClass('alt-color');
        } else {
            navbar.removeClass('alt-color');
        }
    });

    //$('#time-donate').datetimepicker({
    //    container: '#donationModal',
    //}
    //);

    $("#time-donate").datetimepicker().on('show.bs.modal', function (event) {
        container: '#donationModal',
        event.stopPropagation();
    });

    //$('#time-donate').datetimepicker({
    //    autoclose: true,
    //    container: '#donationModal'
    //}).on('hide', function (e) {
    //    e.stopPropagation();
    //});

    $("#donate-btn").click(function () {
        var formData = new FormData();
        formData.append("Email", $("#email-input-donate").val());
        formData.append("Wallet", $("#key-input-donate").val());
        formData.append("Usertype", $("#user-adv-input").val());
        formData.append("Amount", $("#amount-donate").val());
        formData.append("DonateTime", $("#time-donate").val());
        $.ajax({
            url: "/Donation/Index",
            type: 'POST',
            cache: false,
            contentType: false,
            processData: false,
            data: formData,
            success: function (response) {
                $('#successModal').modal('show');
            }
        });
    });




    $("#subscribe-btn").click(function () {
        var formData = new FormData();
        formData.append("Email", $("#email-input-subscribe").val());
        $.ajax({
            url: "/Subscribers/Index",
            type: 'POST',
            cache: false,
            contentType: false,
            processData: false,
            data: formData,
            success: function (response) {
                alert(response);
            }
        });
    });






    $("#linkedin-01").click(function () {
        window.open('https://www.linkedin.com/in/tmihalyi/', '_blank');
    });

    $("#linkedin-02").click(function () {
        window.open('https://www.linkedin.com/in/gregory-szoke-06930511/', '_blank');
    });

    $("#linkedin-03").click(function () {
        window.open('https://www.linkedin.com/in/gyorgy-varro/', '_blank');
    });

    $("#linkedin-04").click(function () {
        window.open('https://www.linkedin.com/in/iamrahulkothari/', '_blank');
    });

    $("#linkedin-05").click(function () {
        window.open('https://www.linkedin.com/in/adam-dragus-846b3911a/', '_blank');
    });

    $("#linkedin-06").click(function () {
        window.open('https://www.linkedin.com/in/doraduszin/', '_blank');
    });

    $("#users-button").click(function () {
        //$('.user-shift-front').css({ 'transform': 'translateX(0%)', 'transition': 'all 1.5s'});
        //$('.user-shift-back').css({ 'transform': 'translateX(0%)', 'transition': 'all 1.5s' });
        $('.flip-box-inner').css({ 'transform': 'translateX(0%)', 'transition': 'all 0.5s' });
        //$("#user-back").addClass('flip-box-back');
    });

    $("#companies-button").click(function () {
        //$("#user-back").removeClass('flip-box-back');
        $('.flip-box-inner').css({ 'transform': 'translateX(135%)', 'transition': 'all 0.5s'});
        //$('.user-shift-back').css({ 'transform': 'translateX(150%)', 'transition': 'all 1.5s' });
        
    });




    $('#video').click(function () {
        console.log("dsa");
        $('#video').css({ 'display': 'inline-block' });
        $('#scrn_video').css({ 'display': 'none' });
        if ($('#video').get(0).paused) {
            console.log("paused");
            $('#video').get(0).play(); $("#playpause").fadeOut();
        } else {
            console.log("not paused");
            $('#video').get(0).pause();
            $("#playpause").fadeIn();
        }
    });

    $('#scrn_video_pic').click(function () {
        console.log("anyad");
        $('#video').css({ 'display': 'inline-block' });
        $('#scrn_video_pic').css({ 'display': 'none' });
        if ($('#video').get(0).paused) {
            console.log("paused");
            $('#video').get(0).play(); $("#playpause").fadeOut();
        } else {
            console.log("not paused");
            $('#video').get(0).pause();
            $("#playpause").fadeIn();
        }
    });



    $('#playpause').click(function () {
        console.log("dsa");
        if ($('#video').get(0).paused) {
            console.log("paused");
            $('#video').get(0).play(); $("#playpause").fadeOut();
        } else {
            console.log("not paused");
            $('#video').get(0).pause();
            $("#playpause").fadeIn();
        }
    });

        $("#offering-user-carousel").swiperight(function () {
            $(this).carousel('prev');
        });
        $("#offering-user-carousel").swipeleft(function () {
            $(this).carousel('next');
        });

        $("#offering-user-carousel-comp").swiperight(function () {
            $(this).carousel('prev');
        });
        $("#offering-user-carousel-comp").swipeleft(function () {
            $(this).carousel('next');
        });


    $('#offering-user-xs').click(function () {
        console.log("user");
        $('#offering-flip-div-01-xs').css({ 'display': 'block' });
        $('#offering-flip-div-02-xs').css({ 'display': 'none' });
    });

    $('#offering-comp-xs').click(function () {
        console.log("comp");
        $('#offering-flip-div-01-xs').css({ 'display': 'none' });
        $('#offering-flip-div-02-xs').css({ 'display': 'block' });
    });
    




    $("#how-user-carousel").swiperight(function () {
        $(this).carousel('prev');
        $('#how-user-square-carousel').carousel('prev');

    });
    $("#how-user-carousel").swipeleft(function () {
        $(this).carousel('next');
        $('#how-user-square-carousel').carousel('next');
    });

    $("#how-user-carousel-comp").swiperight(function () {
        $(this).carousel('prev');
        $('#how-comp-square-carousel').carousel('prev');
    });
    $("#how-user-carousel-comp").swipeleft(function () {
        $(this).carousel('next');
        $('#how-comp-square-carousel').carousel('next');
    });




    $('#how-user-xs').click(function () {
        console.log("user");
        $('#how-card-div-01-xs').css({ 'display': 'block' });
        $('#how-card-div-02-xs').css({ 'display': 'none' });

        $('#how-squares-div-01-xs').css({ 'display': 'block' });
        $('#how-squares-div-02-xs').css({ 'display': 'none' });
    });

    $('#how-comp-xs').click(function () {
        console.log("comp");
        $('#how-card-div-01-xs').css({ 'display': 'none' });
        $('#how-card-div-02-xs').css({ 'display': 'block' });

        $('#how-squares-div-02-xs').css({ 'display': 'block' });
        $('#how-squares-div-01-xs').css({ 'display': 'none' });
    });




    $("#steps-text-mobile-carousel").swiperight(function () {
        $(this).carousel('prev');
    });
    $("#steps-text-mobile-carousel").swipeleft(function () {
        $(this).carousel('next');
    });



    $("#team-carousel").swiperight(function () {
        $(this).carousel('prev');
    });
    $("#team-carousel").swipeleft(function () {
        $(this).carousel('next');
    });

    //$(".flip-container").hover(
    //    function () {
    //        $('.flip-container').css({ '-webkit-box-shadow': 'none', '-moz-box-shadow': 'none', 'box-shadow': 'none' });
    //    }, function () {
    //        $('.flip-container').css({ 'box - shadow' : '0px 4px 12px rgba(0, 0, 0, 0.16)'});
    //    }
    //);

    //autoType(".type-js", 200);
    typingEffect();


    //var barChartData = {
    //    labels: ["", "", "", "", "", "", "", ""],
    //    datasets: [{
    //        fillColor: "#DB2C2F",
    //        strokeColor: "none",
    //        data: [35, 10, 25, 10, 30, 25, 0, 25],
    //        options: { scales: { scaleLabels: { fontSize: 22 } } }
    //    }]
    //}

    //var ctx = document.getElementById("canvas").getContext("2d");
    //var barChartDemo = new Chart(ctx).Bar(barChartData, {
    //    responsive: true,
    //    barValueSpacing: 2
    //});
   

    $('#offering-left-user').click(function () {
        $('#offering-user-carousel').carousel('prev');
    });

    $('#offering-right-user').click(function () {
        $('#offering-user-carousel').carousel('next');
    });

    $('#offering-left-comp').click(function () {
        $('#offering-user-carousel-comp').carousel('prev');
    });

    $('#offering-right-comp').click(function () {
        $('#offering-user-carousel-comp').carousel('next');
    });

    $('#how-left-user').click(function () {
        $('#how-user-square-carousel').carousel('prev');
        $('#how-user-carousel').carousel('prev');
    });

    $('#how-right-user').click(function () {
        $('#how-user-square-carousel').carousel('next');
        $('#how-user-carousel').carousel('next');
    });

    $('#how-left-comp').click(function () {
        $('#how-comp-square-carousel').carousel('prev');
        $('#how-user-carousel-comp').carousel('prev');
    });

    $('#how-right-comp').click(function () {
        $('#how-comp-square-carousel').carousel('next');
        $('#how-user-carousel-comp').carousel('next');
    });





    $('#steps-left').click(function () {
        $('#steps-text-mobile-carousel').carousel('prev');
    });

    $('#steps-right').click(function () {
        $('#steps-text-mobile-carousel').carousel('next');
    });



    $('#team-left').click(function () {
        $('#team-carousel').carousel('prev');
    });

    $('#team-right').click(function () {
        $('#team-carousel').carousel('next');
    });


    


















});







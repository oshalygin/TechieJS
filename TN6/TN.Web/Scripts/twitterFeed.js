        (function() {

            $.ajax({
                url: '@Url.Action("GetTwitterFeed", "Twitter")',
                data: {},
                type: "POST",
                contentType: "application/json",
                dataType: "json",
                timeout: 10000,
                success: function(result) {
                    if (result.hasOwnProperty("d")) {
                        bindTweets(result.d);
                    } else {
                        bindTweets(result);
                    }

                },
                error: function(xhr, status) {
                    alert(status + " - " + xhr.responseText);
                }
            });


            function bindTweets(result) {
                var json = $.parseJSON(result);


                for (var i = 0; i < json.length; i++) {


                    //Time Calculation for displaying in " ago " format...
                    //Parse the twitter date into a raw UTC value.

                    //This part is a little tricky with IE.
                    //Generic example
                    //$(function () {
                    //    $.getJSON("http://twitter.com/statuses/user_timeline/google.json?count=1&callback=?", function (data) {
                    //        $.each(data, function () {
                    //            var created = parseDate(this.created_at);
                    //            $("<div></div>").append("<ul><li>Unformatted: " + this.created_at + "</li><li>Formatted: " + created + "</li></ul>").appendTo("body");
                    //        });
                    //    });
                    //    function parseDate(str) {
                    //        var v = str.split(' ');
                    //        return new Date(Date.parse(v[1] + " " + v[2] + ", " + v[5] + " " + v[3] + " UTC"));
                    //    }
                    //});

                    //Original
                    //var time = Date.parse(json[i].created_at);

                    function parseDate(str) {
                        var v = str.split(' ');
                        return new Date(Date.parse(v[1] + " " + v[2] + ", " + v[5] + " " + v[3] + " UTC"));
                    }


                    var time = parseDate(json[i].created_at);


                    var timeDifference = (new Date() - time) / 1000;
                    var units = ['second', 'minute', 'hour', 'day', 'week'];
                    var maximumValues = [60, 60, 24, 7];
                    for (var unitIndex = 0; timeDifference > maximumValues[unitIndex] && unitIndex < units.length; unitIndex++) {
                        timeDifference /= maximumValues[unitIndex];
                    }
                    timeDifference = parseInt(timeDifference);
                    var unit = units[unitIndex];
                    if (timeDifference > 1) {
                        unit += 's';
                    }
                    var timeAgo = timeDifference + ' ' + unit + ' ago';

                    //End of Conversion


                    $("#twitterFeed").append('<div class="blog-twitter-inner"><i class="fa fa-twitter"></i> <a href="https://twitter.com/oshalygin">@@oshalygin</a>    ' + twttr.txt.autoLink(json[i].text) + '<br />  <span><strong>' + timeAgo + '</strong></span>');

                    try {
                        for (var j = 0; j < json[i].entities.media.length; j++) {
                            $("#results").append('<a href="' + json[i].entities.media[j].media_url + '" ><img src="' + json[i].entities.media[j].media_url + ':thumb" /></a>');
                        }

                    } catch(e) {
                    }
                }
            }


        });

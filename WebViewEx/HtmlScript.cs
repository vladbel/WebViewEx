using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebViewEx
{
    public static class HtmlScript
    {
        #region "script1"

        public static string Script1 = @"
                                <html>
                                <head>
                                
                                    <script>
                                        function notifyHost() {
                                            console.log('Notify Host: try to raise notification for hosting app.');
                                            try {
                                                window.external.notify('notification argument');
                                            } catch (e) {
                                                var element = document.getElementById('output');
                                                if (element) {
                                                    element.innerHTML = 'Error notifyng host';
                                                }
                                                console.log(e);
                                            }            
                                        }
                                
                                        function handleInvokeScript(args) {
                                            console.log('Script invoked', args);
                                            var element = document.getElementById('output');
                                            if (element) {
                                                element.innerHTML = 'Script invoked' + args;
                                            }
                                        }
                                    </script>
                                </head>
                                <body>
                                    <div id='output'></div>
                                
                                    <button onclick='notifyHost()'> Notify Host</button>
                                </body>
                                </html>
                                ";
        #endregion

        #region " script 2"

        public static string Script2 = @"
                                <!DOCTYPE HTML PUBLIC '-//W3C//DTD XHTML 1.0 Strict//EN'
                                          'http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd'>
                                <html onselectstart='return false;' xmlns='http://www.w3.org/1999/xhtml'>
                                <head>
                                    <meta http-equiv='content-type' content='text/html; charset=utf-8' />
                                    <meta http-equiv='cache-control' content='max-age=0' />
                                    <meta http-equiv='cache-control' content='no-cache' />
                                    <meta http-equiv='expires' content='0' />
                                    <meta http-equiv='expires' content='Tue, 01 Jan 1980 1:00:00 GMT' />
                                    <meta http-equiv='pragma' content='no-cache' />

                                    <!-- Use SmartApp Specified Title -->
                                    <title>test title</title>

                                    <!-- TODO: Add our own CSS
                                    <link rel='stylesheet' href='' type='text/css' media='screen' />
                                    -->
                                    <meta name='apple-mobile-web-app-capable' content='yes'>
                                    <meta name='viewport' content='width = device-width'>
                                    <meta name='viewport' content='initial-scale = 1.0, user-scalable=no'>

                                    <!-- Inject SmartApp Specified Head -->
                                    <script src='http://ajax.googleapis.com/ajax/libs/jquery/1.11.0/jquery.min.js'></script>

                                </head>

                                <body>

                                    <!-- Inject SmartApp Specified Body -->

                                    <div>
                                        <div>
                                            <a id='ACTION' href='javascript://'>ACTION</a>
                                        </div>
                                    </div>
                                    <br />
                                    <div>
                                        <div>
                                            <a id='GET' href='javascript://'>GET</a>
                                        </div>
                                        <div>
                                            <a id='PUT' href='javascript://'>PUT</a>
                                        </div>
                                        <div>
                                            <a id='POST' href='javascript://'>POST</a>
                                        </div>
                                        <div>
                                            <a id='DELETE' href='javascript://'>DELETE</a>
                                        </div>
                                    </div>
                                    <br />
                                    <div>
                                        <div>
                                            <a id='GETdata' href='javascript://'>GET with data</a>
                                        </div>
                                        <div>
                                            <a id='PUTdata' href='javascript://'>PUT with data</a>
                                        </div>
                                        <div>
                                            <a id='POSTdata' href='javascript://'>POST with data</a>
                                        </div>
                                        <div>
                                            <a id='DELETEdata' href='javascript://'>DELETE with data</a>
                                        </div>
                                    </div>

                                    <script>
                                  $('#ACTION').click(function(){
                                      deviceCommand('testAction');
                                      return false;
                                  });

                                  $('#GETdata').click(function(){
                                      ST.request('test')
                                        .data({'foo': 'bar'})
                                        .success(function(response){ console.log('success!') })
                                        .error(function(){ console.warn('error!') })
                                        .GET();
                                      return false;
                                  });
                                  $('#PUTdata').click(function(){
                                      ST.request('test')
                                        .data({'foo': 'bar'})
                                        .success(function(response){ console.log('success!') })
                                        .error(function(){ console.warn('error!') })
                                        .PUT();
                                      return false;
                                  });
                                  $('#POSTdata').click(function(){
                                      ST.request('test')
                                        .data({'foo': 'bar'})
                                        .success(function(response){ console.log('success!') })
                                        .error(function(){ console.warn('error!') })
                                        .POST();
                                      return false;
                                  });
                                  $('#DELETEdata').click(function(){
                                      ST.request('test')
                                        .data({'foo': 'bar'})
                                       .success(function(response){ console.log('success!') })
                                        .error(function(){ console.warn('error!') })
                                        .DELETE();
                                      return false;
                                  });

                                  function requestReceived(evt){
                                               console.log('requestReceived', evt);
                                  }

                                    </script>


                                    <!-- Inject SmartThings JS -->
                                    <script id='SmartThingsInjectedJS'>
			                                (function (window, libraryType, baseUrl) {

				                                var libType = {
					                                IOS: 'IOS',
					                                IOS_WEBKIT:'IOS_WEBKIT',
					                                ANDROID: 'ANDROID',
					                                WINDOWS: 'WINDOWS',
					                                WEB: 'WEB'
				                                };

				                                function generateUUID() {
					                                var date = new Date().getTime();
					                                var uuid = 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function(c) {
						                                var r = (date + Math.random()*16)%16 | 0;
						                                date = Math.floor(date/16);
						                                return (c=='x' ? r : (r&0x3|0x8)).toString(16);
					                                });
					                                return uuid;
				                                }

				                                // SmartThings Injected Javascript
				                                var SmartThing = function (type) {
					                                this.addEventHandlers = [];
					                                this.requests = {};
					                                // ios, iosWebKit, android, windows, web
					                                this.type = type;
				                                };

				                                // Receiving events from the client
				                                SmartThing.prototype.receivedEvent = function (event) {
					                                if (typeof window[event.value] === 'function') {
						                                // safe to use function with the name matching event.value
						                                window[event.value](event);
					                                } else if (typeof window[event.name] === 'function') {
						                                // safe to use function with the name matching event.name
						                                window[event.name](event);
					                                } else if (typeof window.eventReceived === 'function') {
						                                // safe to use the eventReceived
						                                eventReceived(event);
					                                }

					                                for (var i = 0; i < this.addEventHandlers.length; i++) {
						                                var cb = this.addEventHandlers[i];
						                                if (typeof cb === 'function') {
							                                cb(event);
						                                }
					                                }
				                                };

				                                SmartThing.prototype.addEventHandler = function (callback) {
					                                this.addEventHandlers.push(callback);
				                                };

				                                SmartThing.prototype.removeEventHandler = function (callback) {
					                                var index = this.addEventHandlers.indexOf(callback);
					                                if (index >= 0) {
						                                this.addEventHandlers.splice(index, 1);
					                                }
				                                };

				                                SmartThing.prototype.request = function (path) {
					                                return new this.SmartRequest(this).setPath(path);
				                                };

				                                SmartThing.prototype.action = function (command) {
					                                var request = {
						                                id: generateUUID(),
						                                method: 'ACTION',
						                                path: command
					                                };

					                                // Check if iOS and add request for getSmartRequestMessage
					                                if (this.type === libType.IOS) {
						                                this.requests[request.id] = request;
					                                }

					                                this.postSmartThingsMessage(request);
				                                };

				                                SmartThing.prototype.executeRequest = function (request) {
					                                this.requests[request.id] = request;
					                                this.postSmartThingsMessage({
						                                id: request.id,
						                                method: request.method,
						                                path: request.path,
						                                params: request.params,
						                                // TODO remove these once all clients have updated
						                                success: '(' + String(request.successHandler) + ')(${SmartResponseObject})',
						                                error: '(' + String(request.errorHandler) + ')(${SmartResponseObject})'
					                                });
				                                };

				                                SmartThing.prototype.SmartRequest = function (smartThings) {
					                                this.smartThings = smartThings;
					                                this.id = generateUUID();
					                                this.method = 'GET';
					                                this.path = '';
					                                this.params = {};
					                                this.successHandler = function () {};
					                                this.errorHandler = function () {};

					                                this.setPath = function (path) {
						                                this.path = path;
						                                return this;
					                                };
					                                this.data = function (params) {
						                                this.params = params;
						                                return this;
					                                };
					                                this.success = function (success) {
						                                this.successHandler = success;
						                                return this;
					                                };
					                                this.error = function (error) {
						                                this.errorHandler = error;
						                                return this;
					                                };
					                                this.GET = function () {
						                                this.method = 'GET';
						                                this.smartThings.executeRequest(this);
					                                };
					                                this.PUT = function () {
						                                this.method = 'PUT';
						                                this.smartThings.executeRequest(this);
					                                };
					                                this.POST = function () {
						                                this.method = 'POST';
						                                this.smartThings.executeRequest(this);
					                                };
					                                this.DELETE = function () {
						                                this.method = 'DELETE';
						                                this.smartThings.executeRequest(this);
					                                };
				                                };

				                                // native client code call this on message success
				                                SmartThing.prototype.receivedSmartThingsMessageSuccess = function (uuid, data) {
					                                var request = this.requests[uuid];
					                                delete this.requests[uuid];
					                                if (request && typeof request.successHandler === 'function') {
						                                request.successHandler(data);
					                                }
				                                };

				                                // native client code call this on message error
				                                SmartThing.prototype.receivedSmartThingsMessageError = function (uuid, error) {
					                                var request = this.requests[uuid];
					                                delete this.requests[uuid];
					                                if (request && typeof request.errorHandler === 'function') {
						                                request.errorHandler(error);
					                                }
				                                };

				                                switch (libraryType) {
					                                case libType.IOS:
						                                SmartThing.prototype.postSmartThingsMessage = function (message) {
							                                var messagingIframe = document.createElement('iframe');
							                                messagingIframe.id = 'STMessagingIframe';
							                                messagingIframe.style.display = 'none';
							                                messagingIframe.src = 'smartthings://' + message.id;

							                                // put the iframe into the doc so the request fires
							                                document.documentElement.appendChild(messagingIframe);
							                                // remove the iframe from the doc because it's useless
							                                document.documentElement.removeChild(messagingIframe);
							                                messagingIframe = null;
						                                };

						                                SmartThing.prototype.getSmartRequestMessage = function (uuid) {
							                                var request = this.requests[uuid];

							                                // Remove ACTION request since it will not be used for callbacks
							                                if (request.method === 'ACTION') {
								                                delete this.requests[uuid];
							                                }

							                                return JSON.stringify({
								                                id: request.id,
								                                method: request.method,
								                                path: request.path,
								                                params: request.params,
								                                // TODO remove these once all clients have updated
								                                success: '(' + String(request.successHandler) + ')(${SmartResponseObject})',
								                                error: '(' + String(request.errorHandler) + ')(${SmartResponseObject})'
							                                });
						                                };

						                                break;
					                                case libType.IOS_WEBKIT:
						                                SmartThing.prototype.postSmartThingsMessage = function (message) {
							                                webkit.messageHandlers.smartthings.postMessage(message);
						                                };

						                                break;
					                                case libType.ANDROID:
						                                SmartThing.prototype.postSmartThingsMessage = function (message) {
							                                smartMessageHandler.handleMessage(JSON.stringify(message));
						                                };

						                                break;
					                                case libType.WINDOWS:
						                                SmartThing.prototype.postSmartThingsMessage = function (message) {
							                                window.external.notify(JSON.stringify(message));
						                                };

						                                break;
					                                default:
						                                SmartThing.prototype.postSmartThingsMessage = (function () {
							                                return function postSmartThingsMessage(message) {
								                                var msg = {
									                                method: message.method,
									                                data: message.params,
									                                url: (baseUrl || '') + message.path,
									                                dataType: 'json',
									                                success: function (data) {
										                                ST.receivedSmartThingsMessageSuccess(message.id, data);
									                                },
									                                error: function (data) {
										                                ST.receivedSmartThingsMessageError(message.id, data);
									                                }
								                                };

								                                if (msg.method === 'POST' || msg.method === 'PUT') {
									                                msg.data = JSON.stringify(message.params);
									                                msg.contentType = 'application/json; charset=utf-8';
								                                }

								                                $.ajax(msg);
							                                };
						                                })();

						                                break;
				                                }

				                                window.ST = new SmartThing(libraryType);
			                                })(window, 'WINDOWS', 'https://dgraph.api.smartthings.com/api/devices/05d4a03d-798a-4a39-b4ed-90fd5a6f2498/');

		                                // Adding backwards compatibility

			                                window.injectEvent = ST.receivedEvent.bind(ST);


                                    </script>


                                </body>
                                </html>
            ";
        #endregion

        #region " script 3"

        public static string Script3 = @"
<html onselectstart='return false;' xmlns='http://www.w3.org/1999/xhtml'>
<head>
    <!-- Use SmartApp Specified Title -->
    <title>test title</title>

    <script src='http://ajax.googleapis.com/ajax/libs/jquery/1.11.0/jquery.min.js'></script>

</head>

<body>

    <!-- Inject SmartApp Specified Body -->

    <br />
    <div>
        <div>
            <a id='GETdata' href='javascript://'>GET with data</a>
        </div>
    </div>

    <script>


        $('#GETdata').click(function () {
            ST.request('test');
            return false;
        });


        function requestReceived(evt) {
            console.log('requestReceived', evt);
        };

        function invokeScriptGlobal(arg1, arg2) {
            console.log('invokeScriptGlobal', arg1, arg2);
            ST.receivedSmartThingsMessageSuccess(arg1, arg2);

        };

    </script>

    <!-- This is simplifyed injected script: just -->
    <script>

        (function () {

            var SmartThing = function () { };

            /**
              * Notify host
              */
            SmartThing.prototype.request = function () {
                console.log('Notify Host: try to raise notification for hosting app.');
                try {
                    window.external.notify('notification argument');
                } catch (e) {
                    var element = document.getElementById('output');
                    if (element) {
                        element.innerHTML = 'Error notifyng host';
                    }
                    console.log(e);
                }
            }


            // success callback
            SmartThing.prototype.receivedSmartThingsMessageSuccess = function (arg1, arg2) {
                console.log('SmartThings1.prototype.receivedSmartThingsMessageSuccess', arg1, arg2);
            };

            window.ST = new SmartThing();
            console.log('initialized', ST);

        })();

    </script>
</body>
</html>




        ";
        #endregion

        #region "Classic Module pattern"
        public static string ClassicModulePattern = @"    


                <html onselectstart='return false;' xmlns='http://www.w3.org/1999/xhtml'>
                <head>
                    <!-- Use SmartApp Specified Title -->
                    <title>test title</title>
                    <script src='http://ajax.googleapis.com/ajax/libs/jquery/1.11.0/jquery.min.js'></script>
                </head>

                <body>

                    <!-- Inject SmartApp Specified Body -->

                    <br />
                    <div>
                        <div>
                            <a id='GETdata' href='javascript://'>GET with data</a>
                        </div>
                    </div>

                    <script>


                        $('#GETdata').click(function () {
                            ST.request('test');
                            return false;
                        });


                        function requestReceived(evt) {
                            console.log('requestReceived', evt);
                        };

                        function invokeScriptGlobal(arg1, arg2) {
                            console.log('invokeScriptGlobal', arg1, arg2);
                            ST.receivedSmartThingsMessageSuccess(arg1, arg2);

                        };

                    </script>

                    <!-- This is simplifyed injected script: just -->
                    <script>

                        var ST = (function () {
                            var SmartThing = { };

                            /**
                              * Notify host
                              */
                            SmartThing.request = function () {
                                console.log('Notify Host: try to raise notification for hosting app.');
                                try {
                                    window.external.notify('notification argument');
                                } catch (e) {
                                    var element = document.getElementById('output');
                                    if (element) {
                                        element.innerHTML = 'Error notifyng host';
                                    }
                                    console.log(e);
                                }
                            }


                            // success callback
                            function receivedSmartThingsMessageSuccess(arg1, arg2) {
                                console.log('SmartThings1.prototype.receivedSmartThingsMessageSuccess', arg1, arg2);
                            };
                            SmartThing.receivedSmartThingsMessageSuccess = receivedSmartThingsMessageSuccess;

                            console.log('initialized', SmartThing);
                            return SmartThing;
                        })();
                    </script>
                </body>
                </html>




        ";
        #endregion

        #region "Type Script style pattern"
        // see JavaScript\TSClassPattern.js
        public static string TypeScriptClassPattern = @"
            <html onselectstart='return false;' xmlns='http://www.w3.org/1999/xhtml'>
            <head>
                <title>test title</title>
                <script src='http://ajax.googleapis.com/ajax/libs/jquery/1.11.0/jquery.min.js'></script>
            </head>
            <body>
                <br />
                <div>
                    <div>
                        <a id='GETdata' href='javascript://'>GET with data</a>
                    </div>
                </div>

                <script>

                    $('#GETdata').click(function () {
                        ST.request('test');
                        return false;
                    });


                    function requestReceived(evt) {
                        console.log('requestReceived', evt);
                    };

                    function invokeScriptGlobal(arg1, arg2) {
                        console.log('invokeScriptGlobal', arg1, arg2);
                        ST.receivedSmartThingsMessageSuccess(arg1, arg2);

                    };

                </script>

                <script>
                    var SmartThing = (function () {
                        /// constructor
                        function SmartThing(message) {
                            this._message = message;
                        }

                        SmartThing.prototype.request = function () {
                            console.log('Notify Host: try to raise notification for hosting app.');
                            try {
                                window.external.notify('notification argument');
                            } catch (e) {
                                var element = document.getElementById('output');
                                if (element) {
                                    element.innerHTML = 'Error notifyng host';
                                }
                                console.log(e);
                            }
                        };

                        SmartThing.prototype.receivedSmartThingsMessageSuccess = function (arg1, arg2) {
                            console.log('SmartThings.prototype.receivedSmartThingsMessageSuccess', arg1, arg2);
                        };

                        return SmartThing;
                    })();

                    var ST = new SmartThing('foo');
                    console.log('ST: ', ST);
                    console.log('ST.__proto__: ', ST.__proto__);
                    console.log('ST.receivedSmartThingsMessageSuccess');
                    console.log(ST.receivedSmartThingsMessageSuccess(1,2));
                </script>
            </body>
            </html>



        ";
        #endregion
    }
}

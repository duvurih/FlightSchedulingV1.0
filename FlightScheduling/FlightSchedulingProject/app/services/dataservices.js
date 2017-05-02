(function () {
    'use strict';

    var serviceId = 'dataservices';
    angular.module('app').factory(serviceId, ['$http', '$window', 'common',dataservices]);

    function dataservices($http, $window, common) {
        var $q = common.$q;
        var logError = common.logger.getLogFn('app', 'error');


        var service = {
            query: query,
            post: post
        };

        function query(source, parameterArray) {
            var url = source;
            if (parameterArray) {
                if (_.isArray(parameterArray)) {
                    _.forEach(parameterArray, function (param) {
                        url = url + '/' + param;
                    })
                }
            }

            var deferred = $q.defer();
            return $http.get(url, { headers: { } }).then(
                function success(payload) {
                    deferred.resolve(payload.data);
                    return deferred.promise;
                },
                function error(err, statusCode) {
                    if (err) {
                        if (err.status == 400) {
                            if (err.data.Message) {
                                logError(err.data.Message, { exception: err.data.MessageDetail, cause: err.statusText }, true);
                                return $q.reject(err.data.Message);
                            }
                        }

                        if (err.status == 401) {
                            logError(err.data.Message, { exception: err.data.MessageDetail, cause: err.statusText }, true);
                            return $q.reject(err.data.Message);
                        }

                        if (err.status == 404) {
                            logError(err.data.Message, { exception: err.data.MessageDetail, cause: err.statusText }, true);
                            return $q.reject(err.data.Message);
                        }

                        if (err.status == 500) {
                            logError(err.data.Message, { exception: err.data.MessageDetail, cause: err.statusText }, true);
                            return $q.reject(err.data.Message);
                        }
                    }

                });
        }

        function post(source, dataObject) {
            var url = source;
            var deferred = $q.defer();
            var antiforgerytoken;
            var req = {
                method: 'POST',
                url: url,
                headers: {
                },
                data: { test: 'test' }
            }

            return $http.post(url, JSON.stringify(dataObject)).then(
                function success(payload) {
                    deferred.resolve(payload.data);
                    return deferred.promise;
                },
                function error(err, statusCode) {
                    if (err) {
                        if (err.status == 400) {
                            if (err.data.message) {
                                logError(err.data.Message, { exception: err.data.MessageDetail, cause: err.statusText }, true);
                                return $q.reject(err.data.message);
                            }
                        }

                        if (err.status == 401) {
                            logError(err.data.Message, { exception: err.data.MessageDetail, cause: err.statusText }, true);
                            return $q.reject(err.data.message);
                        }

                        if (err.status == 404) {
                            logError(err.data.Message, { exception: err.data.MessageDetail, cause: err.statusText }, true);
                            return $q.reject(err.data.Message);
                        }

                        if (err.status == 500) {
                            logError(err.data.Message, { exception: err.data.MessageDetail, cause: err.statusText }, true);
                            return $q.reject(err.data.message);
                        }
                    }

                });
        }

        return service;
    }

})();
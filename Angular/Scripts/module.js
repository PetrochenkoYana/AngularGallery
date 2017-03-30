
angular.module('photostore', ['ngRoute'])
    .config([
        '$locationProvider', '$routeProvider',
        function ($locationProvider, $routeProvider) {
            $routeProvider
                /* admin */
                .when('/Angular/mainPage', {
                    templateUrl: '/views/Angular/MainPage.html',
                    controller: 'MainPageController'
                })
                .when('/Angular/gallery', {
                    templateUrl: '/views/Angular/gallery.html',
                    controller: 'GalleryController'
                })
                .when('/Angular/addImg', {
                    templateUrl: '/views/Angular/addImg.html',
                    controller: 'AddImgController'
                })
                .when('/Angular/text', {
                    templateUrl: '/views/Angular/text.html',
                    controller: 'TextController'
                })
                .otherwise({
                    redirectTo: '/Angular/mainPage'
                });

            // Uses HTLM5 history API for navigation
            $locationProvider.html5Mode(true);
        }
    ])
    .controller('TextController', ['$scope', function ($scope) {
        $scope.text = "testa adsf asdf asdf asdf asdf";
        $scope.isEdit = false;

        $scope.goEdit = function () {
            $scope.isEdit = true;
        }

        $scope.applyEdit = function () {
            $scope.isEdit = false;
        }
    }])




    .controller('MainPageController', ['$scope', 'photoservice', function ($scope, photoservice) {
        $scope.remove = function (url) {
            photoservice.remove(url);
        }

        var defered = photoservice.getAll();
        defered.then(function (response) {
            $scope.photos = response.data;
        });

    }])
     .controller('GalleryController', ['$scope', 'photoservice', function ($scope, photoservice) {

         $scope.test = "GC";
         $scope.remove = function (url) {
             photoservice.remove(url);
         }
         $scope.photos = "asdasd";
         var defered = photoservice.getAll();
         defered.then(function (response) {
             $scope.photos = response.data;
         });
     }])

    .controller('AddImgController', ['$scope', 'photoservice', function ($scope, photoservice) {
        $scope.img = {};

        $scope.addImg = function () {
            dataCenter.add($scope.img.name, $scope.img.data);
            $scope.img = {};
        }
    }])
    .service('photoservice', ['$http', function ($http) {
        return {
            getAll: getAll,
            add: add,
            remove: remove
        };

        function getAll() {
            return $http({
                url: '/Photo/GetPhotos'
            });
        }

        function add(fileName, data) {
            var respons = $http({
                method: 'POST',
                url: '/Image/AddImageAjax',
                data: {
                    fileName: fileName,
                    data: data
                },
                headers: { 'Accept': 'application/json' }
            });
            return respons;
        };

        function remove(url) {
            return $http({
                method: 'POST',
                url: '/Image/RemoveImage',
                data: {
                    url: url
                },
                headers: { 'Accept': 'application/json' }
            });
        }
    }])
    .directive("fileread", [function () {
        return {
            scope: {
                fileread: "="
            },
            link: function (scope, element, attributes) {
                element.bind("change", function (changeEvent) {
                    var reader = new FileReader();
                    reader.onload = function (loadEvent) {
                        scope.$apply(function () {
                            scope.fileread = loadEvent.target.result;
                        });
                    }
                    reader.readAsDataURL(changeEvent.target.files[0]);
                });
            }
        }
    }]);;
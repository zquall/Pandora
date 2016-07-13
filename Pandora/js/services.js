'use strict';

/* Services */

angular.module('Pandora.services', [])
    .value('device', DevExpress.devices.current())
    .value('navigationItems', [
        {
            title: 'Home',
            text: 'Home',
            uri: '/home',
            icon: 'home'
        },
        {
            title: 'Alquileres',
            text: 'Alquileres',
            uri: '/about',
            icon: 'info'
        }
    ])
    .factory('currentViewInfo', ['$rootScope', 'navigationItems', function($rootScope, navigationItems) {
        var selectedIndex;
        var viewTitle;

        $rootScope.$on('$routeChangeStart', function(event, nextLoc, currentLoc) {
            if(nextLoc.$$route) {
                selectedIndex = $.inArray(nextLoc.$$route.originalPath, $.map(navigationItems, function(item) {
                    return item.uri;
                }));
                if(selectedIndex > -1) {
                    viewTitle = navigationItems[selectedIndex].title;
                } else {
                    viewTitle = undefined;
                }
            }
        });

        return {
            getSelectedIndex: function() {
                return selectedIndex;
            },
            getTitle: function() {
                return viewTitle;
            }
        }
    }]);
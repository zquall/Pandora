'use strict';

var products = [{
    key: "Televisions",
    items: [
    { text: "SuperLCD 42", price: "$1200", src: "images/products/7.png" },
    { text: "SuperLED 42", price: "$1450", src: "images/products/5.png" },
    { text: "SuperLED 50", price: "$1600", src: "images/products/4.png" },
    { text: "SuperLCD 55", price: "$1350", src: "images/products/6.png" },
    { text: "SuperLCD 70", price: "$4000", src: "images/products/9.png" }
    ]
},
    {
        key: "Monitors",
        items: [
        { text: "DesktopLCD 19", price: "$160", src: "images/products/10.png" },
        { text: "DesktopLCD 21", price: "$170", src: "images/products/12.png" },
        { text: "DesktopLED 21", price: "$180", src: "images/products/13.png" }
        ]
    },
       {
           key: "Projectors",
           items: [
           { text: "Projector Plus", price: "$550", src: "images/products/14.png" },
           { text: "Projector PlusHD", price: "$750", src: "images/products/15.png" }
           ]
       },
    {
        key: "Video Players",
        items: [
            { text: "HD Video Player", price: "$220", src: "images/products/1.png" },
            { text: "SuperHD Video Player", price: "$270", src: "images/products/2.png" }
        ]
    }
]

/* Controllers */

angular.module('Pandora.controllers', [])
    .controller('LayoutCtrl', ['$scope', '$location', 'navigationItems', 'device', 'currentViewInfo', function($scope, $location, navigationItems, device, currentViewInfo) {
        var that = this;
        
        that.includePath = 'partials/pivotLayout.html';
        
        that.navigationItems = navigationItems;

        that.hasToolbar = true;

        currentViewInfo.setHasToolbar = function(hasToolbar) {
            that.hasToolbar = hasToolbar;
        };

        $scope.$watch(currentViewInfo.getSelectedIndex, function(selectedIndex) {
            that.selectedIndex = selectedIndex;
        });

        that.navigationItemSelected = function(e) {
            $location.path(e.addedItems[0].uri);
        };
    }])

    .controller('ToolbarCtrl', ['$scope', 'currentViewInfo', 'device', function($scope, currentViewInfo, device) {
        var that = this;

        var topToolbar = device.platform === 'ios' || device.platform === 'generic';

        that.items = [];
        
        if(topToolbar) {
            that.items.push({
                location: 'center'
            });

            that.title = currentViewInfo.getTitle();
            $scope.$watch(currentViewInfo.getTitle, function(title) {
                that.title = title;
            });

            var itemIndex = that.items.length - 1;
            var optionPath = 'items[' + itemIndex + '].text';
            
            that.bindingOptions = {};
            that.bindingOptions[optionPath] = 'toolbar.title';
        }

        that.renderAs = topToolbar ? 'topToolbar' : 'bottomToolbar';

        currentViewInfo.setHasToolbar(!!that.items.length);
    }])
    .controller('HomeCtrl',  ['$scope', function ($scope) {

    }])
    .controller('AboutCtrl', function() {
    });
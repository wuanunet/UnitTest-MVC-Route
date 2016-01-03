Feature: DefaultRouteFeature
	為了確保網站的預設路由設定正確
    讓運行可以正常運作


Scenario: 檢查出應該存在且正確的預設路由設定
	Given 外部呼叫的網址為 "Home/Index"
	When 在進入網站，經過路由配對流程之後
	Then 配對結果，預期符合Controller為 "Home"，Action為 "Index"
    And 且這個比對結果是存在又正確的路由

Scenario: 檢查出不存在的預設路由設定
	Given 外部呼叫的網址為 "Home/Index/1/Test"
	When 在進入網站，經過路由配對流程之後
	Then 配對結果，預期是一個不存在的路由
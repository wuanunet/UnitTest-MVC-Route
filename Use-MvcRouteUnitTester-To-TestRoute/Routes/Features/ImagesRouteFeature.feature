Feature: ImagesRouteFeature
	為了確保網站的圖檔路由設定正確
    讓運行可以正常運作


Scenario: 檢查出應該存在且正確的圖檔路由設定
	Given 外部呼叫的網址為 "Images/Original/type/id/version"
	When 在進入網站，經過路由配對流程之後
	Then 配對結果，預期符合Controller為 "Images"，Action為 "RenderOriginal"，以及類別、序號、版本參數設定
    And 且這個比對結果是存在又正確的路由
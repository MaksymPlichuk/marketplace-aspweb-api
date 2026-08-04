# Devlog — MarketPlace API

## 2026-07-23 — 10-11:30: Services
Зробив: Заготовки для ItemService, Перші Dto, працюю над ItemDto та розбираюсь як їх пов'язати, створив заготовку для ItemController.
Застряг на: пов'язанні Dto та новим маппером
Наступного разу: Більше часу дивитися документацію https://mapperly.riok.app/docs/getting-started/first-mapper/

## 2026-07-23 — 17:45: Services
Зробив: додав Mapperly
Застряг на: видає null при перетворенні ItemCategory у Dto. Бо category=null і його потрібно include
Наступного разу: Подивився через Debug і зробив Include у ItemService

## 2026-07-24 — 10:45: Services
Зробив: Доробив Dto dependency
Застряг на: видає null при перетворенні, коли додав UserForInfo dto, але він сам окремо добре підвантажується
Наступного разу: Перевірити Include для всіх Dtos які мають UserForInfoDto

## 2026-07-29 — 16:30: Services
Зробив: Доробив CreateItemAsync
Застряг на: видає null при створенні ItemDto: insert або update в таблиц? "Items" порушує обмеження зовн?шнього ключа "FK_Items_AspNetUsers_SellerId"
Наступного разу: Перевірити типи данних зовнішніх ключів

## 2026-08-04 — 18:30: RTK Query
Зробив: Доробив RTK Get
Застряг на: з'являється undefined при формуванні url для запитів http://localhost:5173/undefined/api/item/ при чому бек http://localhost:5087, тобто помилка при діставанні з env
Наступного разу: Перевірити де знаходиться .env файл (не в src)

## 2026-08-04 — 20:00: RTK Query
Зробив: Доробив маппінг з GET
Застряг на: items.map is not a function при виразі { items && items.payload.map( (i) => (<div key={i.Id}>123</div>) ) }
Наступного разу: Проглянути яка відповідь приходить та вибрати саме частину з об'єктами (items.payload)
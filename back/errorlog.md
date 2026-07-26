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

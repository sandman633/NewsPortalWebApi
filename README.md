# NewsPortalWebApi
WebApi for network administration 
API для новостного портала.
Описание приложения
У API есть следующие возможности:
Для пользователей:
- Аутентификация с помощью JSON Web Token
- Получение списка новостей для авторизованных и неавторизованных
пользователей
- Получение комментариев новости для авторизованного пользователя
- Возможность оставить комментарий к новости для авторизованного
пользователя
- Возможность оставить комментарий к любому комментарию новости для
авторизованного пользователя (максимальный уровень вложенности
комментариев - 5). При этом пользователю, на чей комментарий
оставили комментарий, на email приходит соответствующее
уведомление

Для администратора:
- Аутентификация с помощью JSON Web Token
- Получение списка новостей
- Создание новости
- Редактирование новости
- Удаление новости (при удалении новости удаляются все комментарии
связанные с новостью)
- Удаление комментария (при удалении комментария удаляются все его
дочерние комментарии)


Как запустить?

в командой строке запустить команду docker-compose up
для наглядного тестирования прикручен сваггер, для этого необходимо перейти по https://{host}:{port}/swagger/index.html

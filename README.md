Projemizin senaryosuna göre;

Core MVC uygulamamızdan bir kullanıcı excel oluşturmak istiyor, excel oluşturma işlemi uzun sürebilecek bir işlem türü olabilir, çok sayıda kayıt olabilir veya sunucu performans sıkıntıları olabilir bu yüzden excel oluşturma işlemi için kullanıcıyı bir süre bekletebiliriz.
Bu beklemenin önüne geçmek için excel oluşturma isteklerini bir kuyruğa alıp istenilen işlem yapılınca da kullanıcıya dosyanın hazır olduğu bilgisini vereceğimiz bir uygulama yaptım.

Web arayüzünden kullanıcı excel oluştur isteğinde bulunduktan sonra RabbitMQ'ya ilgili istek iletildi. RabbitMQ bunu kuyruğa aldı. Kullanıcı bu esnada web uygulamasında başka işlemler yapmaya devam edebilir. Exceli oluşturacağımız bir worker service oluşturduk.
Burada RabbitMQ kuyruktan gelen mesajları okuyor ve buna göre exceli oluşturuyor, excel oluşturma işlemi bittikten sonra MVC uygulamamızdaki ilgili yola dosyayı bırakıyor. 
MVC tarafında dosyanın oluşturulduğu bilgisi alındığı anda SignalR aracılığı ile kullanıcıya gerçek zamanlı bildirim gönderiliyor. Kullanıcı artık arayüzden excel dosyasını indirebiliyor.

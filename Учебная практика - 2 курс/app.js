const express = require('express');
const mod = require('./modules.js'); // так подключаем методы из своей библиотеки
const app = express()

app.set('view engine', 'hbs')
app.set('views', './templates')
app.use(express.urlencoded({extended:true}));
app.use(express.json());

app.use(express.static('public'));

app.get('/light_veh', mod.light_veh_get);

app.get('/truck', mod.truck_veh_get);

app.get('/moto', mod.moto_veh_get);

app.get('/feed', mod.feed_get);
app.post('/feed', mod.feed_post);
app.get('/feed_change', mod.feed_change_get);
app.post('/feed_change', mod.feed_change_post);
app.get('/feed_del', mod.feed_del_get);
app.post('/feed_del', mod.feed_del_post);

// легковые
app.get('/changan_uni_k', mod.changan_uni_k_get);
app.get('/toyota_harrier', mod.toyota_harrier_get);
app.get('/gaz_3102_volga', mod.gaz_3102_volga_get);
app.get('/lada_vesta', mod.lada_vesta_get);
app.get('/nissan_note', mod.nissan_note_get);

// грузовые
app.get('/mitsubishi_fuso', mod.mitsubishi_fuso_get);
app.get('/zil_133', mod.zil_133_get);
app.get('/baw_tonik', mod.baw_tonik_get);
app.get('/isuzu_elf', mod.isuzu_elf_get);
app.get('/nissan_atlas', mod.nissan_atlas_get);

// мото
app.get('/bmw_r1200rt', mod.bmw_r1200rt_get);
app.get('/ktm_1290_super_duke_r', mod.ktm_1290_super_duke_r_get);
app.get('/honda_cb1000r', mod.honda_cb1000r_get);
app.get('/yamaha_xv_1700_warrior', mod.yamaha_xv_1700_warrior_get);
app.get('/honda_gl1800', mod.honda_gl1800_get);

app.get('/', (req, res) => {
    res.render('app');
})

let port = 3000
app.listen(port, () => {
    console.log(`Сервер запущен: http://localhost:${port}`);
})
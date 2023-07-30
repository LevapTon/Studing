const { urlencoded } = require('express');
const fs = require('fs');
const { request } = require('http');

// легковые
const light_veh_get = (req, res) => {
    let veh = require('./private/lght_veh.json'); // получить массив объектов из файла
    res.render('light_veh', { veh });
}

const changan_uni_k_get = (req, res) => {
    path = './private/lght_veh.json';
    veh_feeds = './private/light_veh/changan_uni_k_feed.json';
    get_veh_page(veh_feeds, path, 0, res);
}

const toyota_harrier_get = (req, res) => {
    path = './private/lght_veh.json';
    veh_feeds = './private/light_veh/toyota_harrier_feed.json';
    get_veh_page(veh_feeds, path, 1, res);
}

const gaz_3102_volga_get = (req, res) => {
    path = './private/lght_veh.json';
    veh_feeds = './private/light_veh/gaz_3102_volga_feed.json';
    get_veh_page(veh_feeds, path, 2, res);
}

const lada_vesta_get = (req, res) => {
    path = './private/lght_veh.json'
    veh_feeds = './private/light_veh/lada_vesta_feed.json';
    get_veh_page(veh_feeds, path, 3, res);
}

const nissan_note_get = (req, res) => {
    path = './private/lght_veh.json';
    veh_feeds = './private/light_veh/nissan_note_feed.json';
    get_veh_page(veh_feeds, path, 4, res);
}

// грузовые
const truck_veh_get = (req, res) => {
    let veh = require('./private/trucks.json'); // получить массив объектов из файла
    res.render('truck', { veh });
}

const mitsubishi_fuso_get = (req, res) => {
    path = './private/trucks.json';
    veh_feeds = './private/truck/mitsubishi_fuso_feed.json';
    get_veh_page(veh_feeds, path, 0, res);
}

const zil_133_get = (req, res) => {
    path = './private/trucks.json';
    veh_feeds = './private/truck/zil_133_feed.json';
    get_veh_page(veh_feeds, path, 1, res);
}

const baw_tonik_get = (req, res) => {
    path = './private/trucks.json';
    veh_feeds = './private/truck/baw_tonik_feed.json';
    get_veh_page(veh_feeds, path, 2, res);
}

const isuzu_elf_get = (req, res) => {
    path = './private/trucks.json';
    veh_feeds = './private/truck/isuzu_elf_feed.json';
    get_veh_page(veh_feeds, path, 3, res);
}

const nissan_atlas_get = (req, res) => {
    path = './private/trucks.json';
    veh_feeds = './private/truck/nissan_atlas_feed.json';
    get_veh_page(veh_feeds, path, 4, res);
}

// мото
const moto_veh_get = (req, res) => {
    let veh = require('./private/moto.json'); // получить массив объектов из файла
    res.render('moto', { veh });
}

const bmw_r1200rt_get = (req, res) => {
    path = './private/moto.json';
    veh_feeds = './private/motos/bmw_r1200rt_feed.json';
    get_moto_page(veh_feeds, path, 0, res);
}

const ktm_1290_super_duke_r_get = (req, res) => {
    path = './private/moto.json';
    veh_feeds = './private/motos/ktm_1290_super_duke_r_feed.json';
    get_moto_page(veh_feeds, path, 1, res);
}

const honda_cb1000r_get = (req, res) => {
    path = './private/moto.json';
    veh_feeds = './private/motos/honda_cb1000r_feed.json';
    get_moto_page(veh_feeds, path, 2, res);
}

const yamaha_xv_1700_warrior_get = (req, res) => {
    path = './private/moto.json';
    veh_feeds = './private/motos/yamaha_xv_1700_warrior_feed.json';
    get_moto_page(veh_feeds, path, 3, res);
}

const honda_gl1800_get = (req, res) => {
    path = './private/moto.json';
    veh_feeds = './private/motos/honda_gl1800_feed.json';
    get_moto_page(veh_feeds, path, 4, res);
}

// страница добавления отзыва
const feed_get = (req, res) => {
    res.render('feed', { }); // render view
}

const feed_post = (req, res) => {
    let feeds = require(veh_feeds); // прочитать данные
    
    let last_id = feeds[feeds.length-1].id; // последний id в массиве
    let new_record = { // формируем объект нового отзыва
        'id': last_id+1,
        'name': req.body.userName,
        'text': req.body.userFeed,
        'rat': Number(req.body.userRat)
    }
    feeds.push(new_record); // добавить в конец массива
    let json_in_str = JSON.stringify(feeds, null, 4); // перевести в строку
    fs.writeFileSync(veh_feeds, json_in_str, 'utf-8'); // записать в файл

    res.redirect(veh_obj.href); // после записи редирект на предыдущую страницу
}

// удаление отзыва
const feed_del_get = (req, res) => {
    let fds = require(veh_feeds);
    fds_id = req.query.del_btn;
    if (fds_id = fds.length) fds_id -= 1; 
    res.render('feed_del', {fds: fds[fds_id]});
}

const feed_del_post = (req, res) => {
    let fds = require(veh_feeds);
    fds.splice(fds_id, 1);
    for (let i = fds_id; i < fds.length; i+=1) {
        fds[i].id -= 1;
    }
    let json_in_str = JSON.stringify(fds, null, 4); // перевести в строку
    fs.writeFileSync(veh_feeds, json_in_str, 'utf-8'); // записать в файл
    res.redirect(veh_obj.href);
}

// изменение отзыва
const feed_change_get = (req, res) => {
    let fds = require(veh_feeds);
    fds_id = req.query.change_btn;
    res.render('feed_change', {fds: fds[fds_id]});
}

const feed_change_post = (req, res) => {
    let feeds = require(veh_feeds);
    feeds[fds_id].name = req.body.userName;
    feeds[fds_id].text = req.body.userFeed;
    feeds[fds_id].rat = Number(req.body.userRat);
    let json_in_str = JSON.stringify(feeds, null, 4); // перевести в строку
    fs.writeFileSync(veh_feeds, json_in_str, 'utf-8'); // записать в файл
    res.redirect(veh_obj.href); // после записи редирект на предыдущую страницу
}

// подсчет рейтинга
const aver_rat = (veh_obj) => {
    let sum = 0; // объявляем переменную, в которой будет храниться сумма всех чисел массива
    for (let i = 0; i < veh_obj.length; i += 1) { // инициализируем цикл
      sum += veh_obj[i].rat; // на каждой итерации прибавляем к сумме значение текущего элемента массива
    }
    return Number(sum / veh_obj.length).toFixed(2); // возвращаем среднее арифметическое
  };

const upd_rat = (new_file, path) => {
    let json_in_str = JSON.stringify(new_file, null, 4); // перевести в строку
    fs.writeFileSync(path, json_in_str, 'utf-8');
}

// страница с транспортом
const get_veh_page = (feed_path, veh_path, veh_id, res) => {
    let veh = require(veh_path);
    let fds = require(feed_path); // получить массив объектов из файла
    veh_obj = veh[veh_id];
    veh_feeds = feed_path;
    veh[veh_id].rat = Number(aver_rat(fds));
    upd_rat(veh, path);
    res.render('veh_page', { veh: veh[veh_id], fds: fds});
}

const get_moto_page = (feed_path, veh_path, veh_id, res) => {
    let veh = require(veh_path);
    let fds = require(feed_path); // получить массив объектов из файла
    veh_obj = veh[veh_id];
    veh_feeds = feed_path;
    veh[veh_id].rat = Number(aver_rat(fds));
    upd_rat(veh, path);
    res.render('moto_page', { veh: veh[veh_id], fds: fds});
}
  
// глобальные переменные
var veh_obj = [];  // ссылка на транспорт
var veh_feeds = '';  // ссылка на отзывы
var fds_id = 0;  // id отзыва


module.exports = {
    feed_get,
    feed_post,
    feed_change_get,
    feed_change_post,
    feed_del_get,
    feed_del_post,
    light_veh_get,
    changan_uni_k_get,
    toyota_harrier_get,
    gaz_3102_volga_get,
    lada_vesta_get,
    nissan_note_get,
    truck_veh_get,
    mitsubishi_fuso_get,
    zil_133_get,
    baw_tonik_get,
    isuzu_elf_get,
    nissan_atlas_get,
    moto_veh_get,
    bmw_r1200rt_get,
    ktm_1290_super_duke_r_get,
    honda_cb1000r_get,
    yamaha_xv_1700_warrior_get,
    honda_gl1800_get
}

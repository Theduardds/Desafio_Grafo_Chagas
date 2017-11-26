app.service("grafoService", function ($http, configService) {

    return {
        criarGrafo: _criarGrafo,
        adicionarNo: _adicionarNo,
        removerNo: _removerNo,
        adicionarAresta: _adicionarAresta,
        removerAresta: _removerAresta
    }

    function _criarGrafo() {
        var request = {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            url: configService.urlApi + 'grafo/criar',
        }
        return $http(request);
    }

    function _adicionarNo (_no) {
        return $http.post(configService.urlApi + "grafo/adicionarNo", { no: _no });
    }

    function _removerNo(_no) {
        return $http.post(configService.urlApi + "grafo/remover", { no: _no })
    }

    function _adicionarAresta(_aresta) {
        return $http.post(configService.urlApi + "grafo/adicionarAresta", { aresta: _aresta });
    }

    function _removerAresta(_aresta) {
        return $http.post(configService.urlApi + "grafo/removerAresta", { aresta: _aresta });
    }
});
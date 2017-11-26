app.controller("grafoCtrl", function ($scope, $http, $location, $routeParams, $rootScope, grafoService, toastr) {
    var vm = $scope;

    var nodesArray = [];
    var edgesArray = [];
    var nodesArray1 = [];
    var nodes = [];
    var nodes1 = [];
    var edges = [];
    vm.network = null;
    vm.clickedEdge = [];
    vm.clickedNode = [];

    var options = {
        groups: {
            appServer: {
                shape: 'icon',
                icon: {
                    face: 'FontAwesome',
                    code: '\uf0e8',
                    size: 50,
                    color: '#57169a'
                },
                color: '#57169a'
            },
            component: {
                shape: 'icon',
                icon: {
                    face: 'FontAwesome',
                    code: '\uf108',
                    size: 50,
                    color: '#484c52'
                },
                color: '#484c52'
            },
            databaseServer: {
                shape: 'icon',
                icon: {
                    face: 'FontAwesome',
                    code: '\uf1c0',
                    size: 50,
                    color: '#ae872a'
                },
                color: '#ae872a'
            },
            proxy: {
                shape: 'icon',
                icon: {
                    face: 'FontAwesome',
                    code: '\uf0ec',
                    size: 50,
                    color: '#781b1b'
                },
                color: '#781b1b'
            },
            user: {
                shape: 'icon',
                icon: {
                    face: 'FontAwesome',
                    code: '\uf2be',
                    size: 50,
                    color: '#00ff7f'
                },
                color: '#00ff7f'
            }
        },
        edges: {
            color: '#000000'
        },
        physics: {
                forceAtlas2Based: {
                    "centralGravity": 0.005,
                    "springLength": 700,
                    "springConstant": 0.715,
                    "avoidOverlap": 0.49
                },
                minVelocity: 0.75,
                solver: "forceAtlas2Based"
        }
    };

    vm.criarGrafo = function () {
        grafoService.criarGrafo()
            .then(function (data) {
                vm.clickedNode = [];
                vm.vertices = data.data.Vertices;
                vm.arestas = data.data.Arestas;
                //console.log(vm.vertices);
                vm.tipos = data.data.Tipos;
                //console.log(vm.arestas);

                if (nodes.length == 0) {
                    vm.transformar();
                }

            });
    };

    vm.transformar = function () {
        var verticesLength = vm.vertices.length;
        for (var i = 0; i < verticesLength; i++) {
            if (vm.vertices[i].TipoAtivo === 1) {
                var l = vm.vertices[i].ApplicationServer.Nome + '\n' + vm.vertices[i].ApplicationServer.Ip;
                var g = 'appServer';
            }

            else if (vm.vertices[i].TipoAtivo === 2) {
                var l = vm.vertices[i].Component.Nome + '\n' + vm.vertices[i].Component.Ip;
                var g = 'component';
            }

            else if (vm.vertices[i].TipoAtivo === 3) {
                var l = vm.vertices[i].DatabaseServer.Nome + '\n' + vm.vertices[i].DatabaseServer.Ip;
                var g = 'databaseServer';
            }

            else if (vm.vertices[i].TipoAtivo === 4) {
                var l = vm.vertices[i].Proxy.Nome + '\n' + vm.vertices[i].Proxy.Ip;
                var g = 'proxy';
            }

            else if (vm.vertices[i].TipoAtivo === 5) {
                var l = vm.vertices[i].User.Usuario;
                var g = 'user';
            }

            var obj = {
                id: vm.vertices[i].Id,
                label: l,
                group: g
            };
            nodesArray.push(obj);
        }

        var arestasLength = vm.arestas.length;
        for (var i = 0; i < arestasLength; i++) {
            var obj1 = {
                from: vm.arestas[i].Origem,
                to: vm.arestas[i].Destino,
                id: vm.arestas[i].Id,
                length: 300,
                width: 3
            };
            edgesArray.push(obj1);
        }
            nodes = new vis.DataSet(nodesArray);
            edges = new vis.DataSet(edgesArray);
            vm.criarNetwork();
    };

    vm.criarNetwork = function () {
        var container = document.getElementById('mynetwork');
        var data = {
            nodes: nodes,
            edges: edges
        };
        vm.network = new vis.Network(container, data, options);      

        vm.network.on('click', function (properties) {
            var ids = properties.nodes;
            vm.clickedNode = nodes.get(ids);
            if (vm.clickedNode.length == 1) {
                toastr.clear();
            }
            $scope.$digest();
            if (vm.clickedNode.length == 1) {
                var a = toastr.info('Id: ' + vm.clickedNode[0].id + '<br>' + 'Nome: ' + vm.clickedNode[0].label, 'Nó', {
                        allowHtml: true
                });
                console.log('dasnjkldand');
            }
            console.log('clicked nodes:', vm.clickedNode);
        });

        vm.network.on('click', function (properties) {
            var ids = properties.edges;
            vm.clickedEdge = edges.get(ids);
            if (vm.clickedEdge.length == 1 && vm.clickedNode.length != 1) {
                toastr.clear();
            }
            $scope.$digest();
            if (vm.clickedEdge.length == 1 && vm.clickedNode.length != 1) {
                var a = toastr.info('Origem: ' + vm.clickedEdge[0].from + '<br>' + 'Destino: ' + vm.clickedEdge[0].to, 'Aresta', {
                    allowHtml: true
                });
                
            }
            console.log('clicked edges:', vm.clickedEdge);
        });
    };

    vm.adicionarNo = function (No) {
        grafoService.adicionarNo(No)
            .then(function (data) {
                console.log(data);
                if (data.status == 200) {
                    $("#modalAdicionarNo").modal("hide");
                    if (data.data.TipoAtivo === 1) {
                            var l = data.data.ApplicationServer.Nome + '\n' + data.data.ApplicationServer.Ip;
                            var g = 'appServer';
                        }

                    else if (data.data.TipoAtivo === 2) {
                        var l = data.data.Component.Nome + '\n' + data.data.Component.Ip;
                            var g = 'component';
                        }

                    else if (data.data.TipoAtivo === 3) {
                        var l = data.data.DatabaseServer.Nome + '\n' + data.data.DatabaseServer.Ip;
                            var g = 'databaseServer';
                        }

                    else if (data.data.TipoAtivo === 4) {
                        var l = No.Proxy.Nome + '\n' + data.data.Proxy.Ip;
                            var g = 'proxy';
                        }

                    else if (data.data.TipoAtivo === 5) {
                            var l = No.User.Usuario;
                            var g = 'user';
                        }

                        var obj = {
                            id: data.data.Id,
                            label: l,
                            group: g
                        };

                        nodes.add(obj);
                    vm.criarGrafo();
                }
            });
    };

    vm.adicionarAresta = function (Aresta) {
        grafoService.adicionarAresta(Aresta)
            .then(function (data) {
                if (data.status == 200) {
                    $("#modalAdicionarAresta").modal("hide");
                    var obj = {
                        from: data.data.Origem,
                        to: data.data.Destino,
                        id: data.data.Id,
                        length: 300,
                        width: 3
                    };
                    edges.add(obj);

                    vm.criarGrafo();
                }
            });
    };

    vm.removerNo = function () {
        grafoService.removerNo(vm.clickedNode[0])
            .then(function (data) {
                if (data.status == 200) {
                    nodes.remove(data.data.Id);
                    vm.clickedNode = [];
                    if (vm.clickedEdge.length == 1)
                        vm.clickedEdge = [];
                    $scope.$digest;
                    vm.criarGrafo();
                } else {
                    vm.mensagemDeErro = data.statusText;
                }

            });
    }

    vm.removerAresta = function () {
        var a = vm.clickedEdge[0];
        var obj = {
            Id: a.id,
            Origem: a.from,
            Destino: a.to
        };
        grafoService.removerAresta(obj)
            .then(function (data) {
                console.log(data);
                if (data.status == 200) {
                    edges.remove(data.data.Id);
                    vm.clickedEdge = [];
                    $scope.$digest;
                    vm.criarGrafo();
                } else {
                    vm.mensagemDeErro = data.statusText;
                }

            });
    }

    vm.buscarNo = function (No) {
        vm.criarGrafo();
        console.log("Nó: ", No);
        for (var i = 0; i < vm.vertices.length; i++){
            if (vm.vertices[i].Id == No.Id) {
                console.log("Nó na lista: ", vm.vertices[i]);
                if (vm.vertices[i].TipoAtivo === 1) {
                    var l = vm.vertices[i].ApplicationServer.Nome + '\n' + vm.vertices[i].ApplicationServer.Ip;
                    var g = 'appServer';
                }

                else if (vm.vertices[i].TipoAtivo === 2) {
                    var l = vm.vertices[i].Component.Nome + '\n' + vm.vertices[i].Component.Ip;
                    var g = 'component';
                }

                else if (vm.vertices[i].TipoAtivo === 3) {
                    var l = vm.vertices[i].DatabaseServer.Nome + '\n' + vm.vertices[i].DatabaseServer.Ip;
                    var g = 'databaseServer';
                }

                else if (vm.vertices[i].TipoAtivo === 4) {
                    var l = vm.vertices[i].Proxy.Nome + '\n' + vm.vertices[i].Proxy.Ip;
                    var g = 'proxy';
                }

                else if (vm.vertices[i].TipoAtivo === 5) {
                    var l = vm.vertices[i].User.Usuario;
                    var g = 'user';
                }

                var obj1 = {
                    id: vm.vertices[i].Id,
                    label: l,
                    group: g
                };

                nodesArray1.push(obj1);
                nodes1 = new vis.DataSet(nodesArray1);
                data1 = {
                    nodes: nodes1,
                };
                var container1 = document.getElementById('mynetwork2');
                vm.network2 = new vis.Network(container1, data1, options); 
                vm.mostrarGrafoBuscar = true;

                vm.network2.on('click', function (properties) {
                    var ids = properties.nodes;
                    vm.clickedNode1 = nodes.get(ids);
                    if (vm.clickedNode1.length == 1) {
                        toastr.clear();
                    }
                    $scope.$digest();
                    if (vm.clickedNode1.length == 1) {
                        var a = toastr.info('Id: ' + vm.clickedNode1[0].id + '<br>' + 'Nome: ' + vm.clickedNode1[0].label, 'Nó', {
                            allowHtml: true
                        });
                    }
                });
            }
        }
    };


    vm.limparEscopo = function () {
        console.log('Limpando escopo...');
        delete vm.No;
        delete vm.Aresta;
        delete vm.network2;
        nodesArray1 = [];
        data1 = [];
        nodes1 = [];
        vm.mostrarGrafoBuscar = false;
        vm.clickedNode = [];
        vm.clickedEdge = [];
        $scope.$digest;
    };

    vm.limparAdicionar = function () {
        delete vm.No.ApplicationServer;
        delete vm.No.Component;
        delete vm.No.DatabaseServer;
        delete vm.No.Proxy;
        delete vm.No.User;
    }

    vm.main = function () {
        vm.criarGrafo();
    };

    vm.main();
});
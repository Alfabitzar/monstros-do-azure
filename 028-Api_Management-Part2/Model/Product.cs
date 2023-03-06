using System.Collections.Generic;
using System.Linq;

namespace Alfabitzar.MonstrosDoAzure.Model;

public class Product
{
    public static List<dynamic> List()
    {
        var products = new dynamic[] {
            new { id = 1, sku = "UTD001", product = "Panela de pressão", description = "Panela de pressão em aço inoxidável com capacidade para 6 litros", weight = 2.5, price = 150, stock = 20 },
            new { id = 2, sku = "UTD002", product = "Conjunto de facas", description = "Conjunto de 5 facas de aço inoxidável com suporte em acrílico", weight = 1, price = 80, stock = 15 },
            new { id = 3, sku = "UTD003", product = "Frigideira antiaderente", description = "Frigideira antiaderente de 24cm com cabo em baquelite", weight = 0.5, price = 40, stock = 30 },
            new { id = 4, sku = "UTD004", product = "Jogo de copos", description = "Jogo de 6 copos de vidro com capacidade para 250ml cada", weight = 2, price = 30, stock = 25 },
            new { id = 5, sku = "UTD005", product = "Jogo de panelas", description = "Jogo de panelas em alumínio com revestimento antiaderente e 5 peças", weight = 4.5, price = 180, stock = 10 },
            new { id = 6, sku = "UTD006", product = "Liquidificador", description = "Liquidificador com potência de 600W e jarra de vidro com capacidade para 1,5 litros", weight = 2.8, price = 120, stock = 12 },
            new { id = 7, sku = "UTD007", product = "Forno elétrico", description = "Forno elétrico com capacidade para 20 litros e controle de temperatura", weight = 8.5, price = 250, stock = 5 },
            new { id = 8, sku = "UTD008", product = "Cafeteira", description = "Cafeteira com capacidade para 1,2 litros e filtro permanente", weight = 1.2, price = 60, stock = 18 },
            new { id = 9, sku = "UTD009", product = "Jogo de talheres", description = "Jogo de talheres em aço inoxidável com 24 peças", weight = 1.8, price = 100, stock = 20 },
            new { id = 10, sku = "UTD010", product = "Tábua de corte", description = "Tábua de corte em bambu com 40cm x 30cm x 2cm", weight = 1.2, price = 25, stock = 30 },
            new { id = 11, sku = "UTD011", product = "Forma para bolo", description = "Forma para bolo em alumínio com diâmetro de 25cm", weight = 0.8, price = 20, stock = 40 },
            new { id = 12, sku = "UTD012", product = "Pipoqueira", description = "Pipoqueira elétrica com capacidade para 100g de milho e bocal direcionador de pipoca", weight = 1.5, price = 70, stock = 8 },
            new { id = 13, sku = "UTD013", product = "Faca elétrica", description = "Faca elétrica para cortar carnes e pães com lâminas em aço inoxidável", weight = 1.2, price = 60, stock = 10 },
            new { id = 14, sku = "UTD014", product = "Jogo de xícaras de chá", description = "Jogo de 4 xícaras de chá em porcelana com capacidade para 250ml cada", weight = 1.5, price = 40, stock = 20 },
            new { id = 15, sku = "UTD015", product = "Mixer", description = "Mixer com potência de 250W e acessórios para bater e misturar alimentos", weight = 1.3, price = 80, stock = 15 },
            new { id = 16, sku = "UTD016", product = "Panela elétrica", description = "Panela elétrica para arroz com capacidade para 5 copos de arroz e função de manter aquecido", weight = 2.8, price = 90, stock = 10 },
            new { id = 17, sku = "UTD017", product = "Assadeira", description = "Assadeira em alumínio com medidas de 35cm x 25cm x 5cm", weight = 1.2, price = 30, stock = 25 },
            new { id = 18, sku = "UTD018", product = "Jogo de potes", description = "Jogo de 3 potes em vidro com capacidade para 1 litro, 2 litros e 3 litros", weight = 3, price = 50, stock = 20 },
            new { id = 19, sku = "UTD019", product = "Espremedor de frutas", description = "Espremedor de frutas elétrico com capacidade para 500ml e cone duplo para diferentes tamanhos de frutas", weight = 2.5, price = 60, stock = 12 },
            new { id = 20, sku = "UTD020", product = "Garrafa térmica", description = "Garrafa térmica em inox com capacidade para 1 litro e sistema de vedação para manter a temperatura", weight = 0.8, price = 50, stock = 15 },
            new { id = 21, sku = "UTD021", product = "Conjunto de potes para mantimentos", description = "Conjunto de 5 potes em plástico com capacidades de 200ml, 500ml, 1L, 1,5L e 2L", weight = 2.5, price = 35, stock = 30 },
            new { id = 22, sku = "UTD022", product = "Escorredor de pratos", description = "Escorredor de pratos em aço inoxidável com capacidade para 15 pratos e suporte para talheres", weight = 1.8, price = 45, stock = 20 },
            new { id= 23, sku = "UTD023", product = "Tábua de corte", description = "Tábua de corte em madeira com medidas de 30cm x 20cm x 2cm", weight = 1.5, price = 25, stock = 35 },
            new { id = 24, sku = "UTD024", product = "Conjunto de facas", description = "Conjunto de 5 facas em aço inoxidável com suporte em acrílico", weight = 2.5, price = 70, stock = 15 },
            new { id = 25, sku = "UTD025", product = "Chaleira elétrica", description = "Chaleira elétrica em inox com capacidade para 1,8 litros e desligamento automático", weight = 1.5, price = 60, stock = 12 },
        };

        return products.ToList();
    }
}
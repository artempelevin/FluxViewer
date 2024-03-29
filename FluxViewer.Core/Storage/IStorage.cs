﻿using System;
using System.Collections.Generic;

namespace FluxViewer.Core.Storage;

/// <summary>
/// Интерфейс взаимодействия с хранилищем показаний прибора.
/// В нём доступны методы чтения/записи показаний.
/// </summary>
public interface IStorage
{
    /// <summary>
    /// Открыть хранилище.
    /// </summary>
    void Open();

    /// <summary>
    /// Закрыть хранилище.
    /// </summary>
    void Close();

    /// <summary>
    /// Добавление показания прибора в хранилище.
    /// </summary>
    /// <param name="data">Структура, описывающая 1 показание прибора</param>
    void WriteData(Data data);

    /// <summary>
    /// Получение количества всех показаний, записанных за всё время.
    /// </summary>
    /// <returns>Количество показаний прибора</returns>
    public long GetDataCount();

    /// <summary>
    /// Получение количества показаний между двумя датами.
    /// </summary>
    /// <param name="beginDate">Дата начала, с которой считаются показания</param>
    /// <param name="endDate">Дата конца, по которую считаются показания</param>
    /// <returns>Количество показаний прибора</returns>
    public long GetDataCountBetweenTwoDates(DateTime beginDate, DateTime endDate);

    /// <summary>
    /// Получить все даты в диапазоне двух дат, в которые прибор записывал показания.
    /// </summary>
    /// <param name="beginDate">Дата начала, с которой начинается поиск</param>
    /// <param name="endDate">Дата окончания, по которую идёт поиск</param>
    /// <returns>Список дат, в которые прибор записывал показания</returns>
    public List<DateTime> GetAllDatesWithDataBetweenTwoDates(DateTime beginDate, DateTime endDate);

    /// <summary>
    /// Записывал ли прибор показания прибора в данную дату?
    /// </summary>
    /// <param name="date">Дата, за которую нужно проверить писал ли прибор показания</param>
    /// <returns>true - если есть данные за эту дату, иначе - false</returns>
    public bool HasDataForThisDate(DateTime date);

    /// <summary>
    /// Получение показаний прибора за конкретную дату.
    /// </summary>
    /// <param name="date">Дата в которую следует искать показания</param>
    /// <returns>Все показания прибора, полученные в текущую дату</returns>
    public List<Data> GetDataBatchByDate(DateTime date);


    /// <summary>
    /// Получение конкретного количества показаний прибора в данном промежутке дат.
    /// Пример: Между 01.02.2021 и 02.02.2021 записано 10000 показаний.
    ///      GetDataBatchBetweenTwoDates(01.02.2021, 02.02.2021, 100) вернёт каждое 100-е показание
    ///      GetDataBatchBetweenTwoDates(01.02.2021, 02.02.2021, 5000) вернёт каждое 2-е показание
    ///      GetDataBatchBetweenTwoDates(01.02.2021, 02.02.2021, 10000) вернёт каждое 1-е показание
    ///      GetDataBatchBetweenTwoDates(01.02.2021, 02.02.2021, 30000) вернёт ТАКЖЕ каждое 1-е показание
    /// </summary>
    /// <param name="beginDate">Дата начала, с которой происходит поиск показаний прибора</param>
    /// <param name="endDate">Дата конца, по которую происходит поиск показаний прибора</param>
    /// <param name="batchSize">Количество точек из данного диапазона, которое хочется получить</param>
    /// <returns>Выборочные показания прибора (в зависимости от размера 'batchSize') в данном диапазоне дат</returns>
    public List<Data> GetDataBatchBetweenTwoDates(DateTime beginDate, DateTime endDate, int batchSize);

    /// <summary>
    /// Получить показания прибора за следующую дату после переданной.
    /// Например:
    ///     У нас есть показания за: 12.01.2022, 14.01.2022 и 17.01.2022.
    ///     GetNextBatchAfterThisDate(12.01.2022) вернёт данные за 14.01.2022.
    ///     GetNextBatchAfterThisDate(14.01.2022) вернёт данные за 17.01.2022.
    ///     GetNextBatchAfterThisDate(17.01.2022) вернёт ошибку!
    /// </summary>
    /// <param name="date">Дата, от которой ищется следующая дата, в которую прибор записывал показания</param>
    /// <exception cref="NextDataBatchNotFoundException">Порождается, если следующая за текущей дата не найдена</exception>
    /// <returns>Показания прибора, если нашлась дата, позже переданной, иначе - ошибка</returns>
    public List<Data> GetNextDataBatchAfterThisDate(DateTime date);

    /// <summary>
    /// Получить показания прибора за предыдущую дату после переданной.
    /// Например:
    ///     У нас есть показания за: 12.01.2022, 14.01.2022 и 17.01.2022.
    ///     GetPrevDataBatchAfterThisDate(12.01.2022) вернёт ошибку!
    ///     GetPrevDataBatchAfterThisDate(14.01.2022) вернёт данные за 12.01.2022.
    ///     GetPrevDataBatchAfterThisDate(17.01.2022) вернёт данные за 14.01.2022.
    /// </summary>
    /// <param name="date">Дата, от которой ищется предыдущая дата, в которую прибор записывал показания</param>
    /// /// <exception cref="PrevDataBatchNotFoundException">Порождается, если следующая за текущей дата не найдена</exception>
    /// <returns>Показания прибора, если нашлась дата, раньше переданной, иначе - ошибка</returns>
    public List<Data> GetPrevDataBatchAfterThisDate(DateTime date);
}

public class NextDataBatchNotFoundException : Exception
{
}

public class PrevDataBatchNotFoundException : Exception
{
}
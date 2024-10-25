WITH TT_MisMatchFlag AS
         (SELECT C2.DURABLE_ID,
                 CASE WHEN CC.DURABLE_STATUS_CODE = C2.DURABLE_STATUS_CODE THEN 'N' ELSE 'Y' END AS MisMatchFlag
          FROM TB_EGN_DURB_INFO CC
                   INNER JOIN TB_EGN_DURB_INFO C2
                              ON C2.REPRESENTATIVE_FACTORY_CODE = CC.REPRESENTATIVE_FACTORY_CODE
                                  AND CC.LOAD_REP_CSTID = C2.DURABLE_ID
          where 1 = 1
            AND CC.REPRESENTATIVE_FACTORY_CODE = $REP_FACTORY_CODE
            AND CASE WHEN CC.DURABLE_STATUS_CODE = C2.DURABLE_STATUS_CODE THEN 'N' ELSE 'Y' END = 'Y')
SELECT CC.DURABLE_ID
     , H.FROM_PORT_iD             AS 요청포트
     , H.TO_PORT_ID               AS 목적포트
     , H.CSTSTAT                  AS 상태
     , W.LOT_ID                   AS LOTID
     , W.FACTORY_AREA_ID          AS 라인
     , W.ROUTE_ID                 AS ROUT
     , H.CMD_STAT_CODE            AS 현황
     , W.PRODUCT_SPECIFICATION_ID AS PRODID
     , W.PROCESS_CODE             AS PROCID
     , W.LOT_DETAIL_STATUS_CODE   AS WIP
     , W.LOT_STATUS_CODE          AS LT
--      , CONVERT(CHAR(23), H.INSDTTM, 20) AS 요청시각
--      , CONVERT(CHAR(23), H.UPDDTTM, 20) AS 수정시각
     , MisMatchFlag
     , W.LANE_ID                  AS LANE_ID
     , CC.ABNORM_TRF_RSN_CODE     AS ATRC
     , W.HOLD_STATUS_CODE         AS HOLD
     , H.RTD_RULE_ID
     , H.TRF_CODE
     , H.INSUSER                  AS 요청
     , H.REQ_SEQNO                AS 순번
     , H.CNCL_REQ_FLAG            AS 취소
     --  , (CASE WHEN (DATEDIFF(minute, H.INSDTTM, GETDATE())>=60) THEN '1' ELSE 'O' END) AS CMDCHK
     , H.RSPN_CODE                AS RSPN
     , C.BUSINESS_USAGE_CODE_DESC AS ERR_MSG
     , H.CMD_STAT_CODE
FROM TB_EGN_DURB_INFO CC
         INNER JOIN TB_MHS_TRF_CMD H
                    ON H.FACILITY_CODE = CC.REPRESENTATIVE_FACTORY_CODE
                        AND H.CSTID = CC.DURABLE_ID
         LEFT JOIN TB_EGN_LOT_INFO W
                   ON W.REPRESENTATIVE_FACTORY_CODE = CC.REPRESENTATIVE_FACTORY_CODE
                       AND W.DURABLE_ID = CC.DURABLE_ID
         LEFT JOIN TB_EGN_CODE_ITEM_INFO C
                   ON C.FACILITY_CODE = CC.REPRESENTATIVE_FACTORY_CODE
                       AND C.BUSINESS_USAGE_TYPE_CODE = 'TRF_REQ_ERR_CODE'
                       AND C.BUSINESS_USAGE_CODE_ID = H.RSPN_CODE
         LEFT JOIN TT_MisMatchFlag TM ON TM.DURABLE_ID = CC.DURABLE_ID
WHERE 1 = 1
  AND NVL(H.CNCL_REQ_FLAG, '') NOT IN ('Y', 'S')
  AND CC.REPRESENTATIVE_FACTORY_CODE = $REP_FACTORY_CODE
--                                    +Option1
--                                    +Option2
--                                    +Option3
--                                    +Option4
--                                    +Option5
--                                    +Option6
--                                    +Option7
--                                    <![CDATA[AND H.INSUSER <> 'MCS(SYNC)' ORDER BY H.INSDTTM DESC]]>